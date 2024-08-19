package com.example.gamesboxd

import android.os.Bundle
import android.view.Menu
import android.view.View
import android.widget.ImageView
import android.widget.TextView
import com.google.android.material.snackbar.Snackbar
import com.google.android.material.navigation.NavigationView
import androidx.navigation.findNavController
import androidx.navigation.ui.AppBarConfiguration
import androidx.navigation.ui.navigateUp
import androidx.navigation.ui.setupActionBarWithNavController
import androidx.navigation.ui.setupWithNavController
import androidx.drawerlayout.widget.DrawerLayout
import androidx.appcompat.app.AppCompatActivity
import com.example.gamesboxd.databinding.ActivityMenuBinding
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.firestore.FirebaseFirestore
import com.bumptech.glide.Glide
import com.google.firebase.firestore.ListenerRegistration

class Menu : AppCompatActivity() {

    private lateinit var appBarConfiguration: AppBarConfiguration
    private lateinit var binding: ActivityMenuBinding

    private lateinit var firebase: FirebaseFirestore
    private lateinit var auth: FirebaseAuth
    private var userListener: ListenerRegistration? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMenuBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setSupportActionBar(binding.appBarMenu.toolbar)

        binding.appBarMenu.fab.setOnClickListener { view ->
            Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                .setAction("Action", null)
                .setAnchorView(R.id.fab).show()
        }
        val drawerLayout: DrawerLayout = binding.drawerLayout
        val navView: NavigationView = binding.navView
        val navController = findNavController(R.id.nav_host_fragment_content_menu)
        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        appBarConfiguration = AppBarConfiguration(
            setOf(
                R.id.nav_home, R.id.nav_conta
            ), drawerLayout
        )
        setupActionBarWithNavController(navController, appBarConfiguration)
        navView.setupWithNavController(navController)

        firebase = FirebaseFirestore.getInstance()
        auth = FirebaseAuth.getInstance()

        val headerView: View = navView.getHeaderView(0)
        val headerNome: TextView = headerView.findViewById(R.id.text_view_user_header)
        val headerEmail: TextView = headerView.findViewById(R.id.text_view_email_header)
        val headerPicture: ImageView = headerView.findViewById(R.id.imageView_foto_header)

        val userId = auth.currentUser?.uid

        if(userId != null){
            userListener = firebase.collection("Users").document(userId)
                            .addSnapshotListener { documento, erro ->
                    if(documento?.exists() == true){
                        val nome = documento.getString("nome")
                        val email = documento.getString("email")
                        val picture = documento.getString("picture")

                        headerNome.setText(nome)
                        headerEmail.setText(email)

                        if(picture != null){
                            Glide.with(this).load(picture).into(headerPicture)
                        } else {
                            headerPicture.setImageResource(R.drawable.baseline_account_circle_24)
                        }
                    }
                }
        }
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Inflate the menu; this adds items to the action bar if it is present.
        menuInflater.inflate(R.menu.menu, menu)
        return true
    }

    override fun onSupportNavigateUp(): Boolean {
        val navController = findNavController(R.id.nav_host_fragment_content_menu)
        return navController.navigateUp(appBarConfiguration) || super.onSupportNavigateUp()
    }

    override fun onDestroy(){
        super.onDestroy()
        userListener?.remove()
    }
}

