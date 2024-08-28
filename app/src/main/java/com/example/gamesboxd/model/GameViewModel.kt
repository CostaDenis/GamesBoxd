package com.example.gamesboxd.model

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.gamesboxd.BuildConfig
import com.example.gamesboxd.network.IGDBService
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class GameViewModel : ViewModel() {

    private val retrofit = Retrofit.Builder()
        .baseUrl("https://api.igdb.com/v4/")
        .addConverterFactory(MoshiConverterFactory.create())
        .build()

    private val service = retrofit.create(IGDBService::class.java)
    val games: MutableLiveData<List<Game>> = MutableLiveData()

    fun fetchGames() {
        viewModelScope.launch {
            try {
                val response = service.findGame(
                    BuildConfig.IGDB_CLIENT_ID,
                    "Bearer ${BuildConfig.IGDB_AUTH_TOKEN}",
                    "fields name; limit 10;"
                )

                if (response.isSuccessful) {
                    games.postValue(response.body())
                } else {
                    Log.e("API_CALL", "Erro: ${response.code()} - ${response.message()}")
                }
            } catch (e: Exception) {
                Log.e("API_CALL", "Exceção: ${e.message}", e)
            }
        }
    }
}