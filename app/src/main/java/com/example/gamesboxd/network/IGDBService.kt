package com.example.gamesboxd.network

import com.example.gamesboxd.model.Game
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.Header
import retrofit2.http.POST

interface IGDBService {

    @POST("games")
    fun findGame(
        @Header("Client-Id") clientId: String,
        @Header("Authorization") authorization: String,
        @Body query: String) : Response<List<Game>>
}