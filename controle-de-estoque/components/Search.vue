<template>
  <div>
    <v-container>
      <v-row>
        <v-col cols="12" md="4">
          <v-select
            v-model="filtroSelecionado"
            :items="opcoesFiltro"
            label="Filtrar por"
            required
          ></v-select>
        </v-col>
        <v-col cols="12" md="8">
          <v-text-field
            v-model="termoPesquisa"
            label="Pesquisar"
          ></v-text-field>
        </v-col>
      </v-row>
    </v-container>
    </div>
  </template>
  
  <script setup lang="ts">
  
  const props = defineProps<{
    opcoesFiltro: string[]
    termoPesquisa: string
    filtroSelecionado: string
  }>()

  </script>