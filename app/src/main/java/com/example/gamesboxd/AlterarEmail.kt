package com.example.gamesboxd

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.view.View
import android.widget.Button
import android.widget.EditText
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.ContextCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.google.android.material.snackbar.Snackbar
import com.google.firebase.auth.EmailAuthProvider
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseUser
import com.google.firebase.firestore.FirebaseFirestore

class AlterarEmail : AppCompatActivity() {

    private val auth = FirebaseAuth.getInstance()
    private val firestore = FirebaseFirestore.getInstance()
    private lateinit var email: String

    private lateinit var inputEmail: EditText
    private lateinit var inputNovoEmail: EditText
    private lateinit var inputSenha: EditText
    private lateinit var btnAlterarEmail: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_alterar_email)

        val userId = auth.currentUser?.uid
        val currentUser = auth.currentUser

        inputEmail = findViewById(R.id.inputEmail)
        inputNovoEmail = findViewById(R.id.inputEmailNovo)
        inputSenha = findViewById(R.id.inputSenhaReautenticacao)
        btnAlterarEmail = findViewById(R.id.btn_AlterarEmail)



        if(userId != null){
            firestore.collection("Users").document(userId).addSnapshotListener{ documento, error ->
                if(documento != null){
                    email = documento.getString("email").toString()
                    inputEmail.setText(email)
                }
            }

            btnAlterarEmail.setOnClickListener {
                val emailAtual = inputNovoEmail.text.toString()
                val senha = inputSenha.text.toString()

                if(email != emailAtual){
                    AtualizacaoEmail(emailAtual, senha, currentUser) { success ->
                        if(success){
                                EsperarVerificacaoEmail(currentUser, userId, emailAtual) { emailVerificado ->

                                    if(emailVerificado){
                                        showSnack("Email atualizado com sucesso!", ContextCompat.getColor(this, R.color.ColorSecundary))
                                    } else {

                                    }
                                }
                        } else {
                            showSnack("Não foi possível alterar o email!", Color.RED)
                        }
                    }

                } else {
                    showSnack("Email inalterado!", Color.GRAY)
                }
            }

        }

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
    }

    private fun showSnack(message: String, color: Int) {
        val view = findViewById<View>(android.R.id.content)
        val snackbar = Snackbar.make(view, message, Snackbar.LENGTH_SHORT)
        snackbar.setBackgroundTint(color)
        snackbar.show()
    }

    fun AtualizacaoEmail(email: String, password: String, currentUser: FirebaseUser?, callback: (Boolean) -> Unit){
        if(password.isEmpty()){
            showSnack("Coloque sua senha antes para editar o email!", Color.RED)
            callback(false)
            return
        }
        currentUser.let{
            val credencial = EmailAuthProvider.getCredential(it?.email!!, password)
            it.reauthenticate(credencial).addOnCompleteListener { reautenticar ->
                if(reautenticar.isSuccessful){
                    it.verifyBeforeUpdateEmail(email).addOnCompleteListener { task ->
                        if(task.isSuccessful){
                            showSnack("Email de verificação enviado para $email.",  ContextCompat.getColor(this, R.color.ColorSecundary))
                            callback(true)
                        } else {
                            showSnack("Erro ao enviar email de verificação: ${task.exception?.message}", Color.RED)
                            callback(false)
                        }
                    }
                } else {
                    showSnack("Erro ao reautenticar. Verifique sua senha e tente novamente!", Color.RED)
                    callback(false)
                }
            }
        }

    }

    fun EsperarVerificacaoEmail(currentUser: FirebaseUser?, userId: String, emailAtual: String, callback: (Boolean) -> Unit) {
        if (currentUser == null) {
            showSnack("Erro: usuário atual é nulo.", Color.RED)
            callback(false)
            return
        }

        currentUser.reload().addOnCompleteListener { reload ->

            if (reload.isSuccessful) {
                firestore.collection("Users").document(userId)
                    .update(mapOf("email" to emailAtual)).addOnCompleteListener { task ->
                        if(task.isSuccessful){
                            showSnack("Email verificado com sucesso!", Color.BLUE)
                        } else {
                            showSnack("Não foi possível atualizar o email", Color.RED)
                        }

                        verificarEmaileLogout(currentUser, emailAtual, callback)
                    }
            } else {
                showSnack("Erro ao recarregar o usuário!", Color.RED)
                callback(false)
            }
        }.addOnFailureListener { exception ->
            showSnack("Erro no recarregamento: ${exception.message}", Color.RED)
            callback(false)
        }
    }

    fun verificarEmaileLogout(currentUser: FirebaseUser, emailAtual: String, callback: (Boolean) -> Unit){
        if(currentUser.isEmailVerified){
            showSnack("Email verificado com sucesso!", Color.BLUE)
        } else {
            showSnack("Email não verificado ainda. Verifique seu email.", Color.YELLOW)
        }

        auth.signOut()
        val intent = Intent(this@AlterarEmail, MainActivity::class.java)
        startActivity(intent)
        finish()
        callback(true)
    }

}

