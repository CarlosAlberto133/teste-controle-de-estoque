<template>
  <div>
    <v-app-bar app color="primary">
      <v-btn color="white" @click="goToHome">
        Controle de Estoque
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn color="white" @click="goToAddProduct">Adicionar Produto</v-btn>
    </v-app-bar>

    <v-main>
      <v-container>
      </v-container>
    </v-main>

  </div>
</template>

<script setup lang="ts">

const router = useRouter()

const goToAddProduct = () => {
  router.push({ name: 'AddProduct' })
}

const goToHome = () => {
  router.push('/')
}

</script>

<style scoped>

</style>