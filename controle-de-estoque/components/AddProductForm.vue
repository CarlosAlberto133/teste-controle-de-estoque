<template>
  <div>
    <v-container>
      <v-col cols="12">
        <h2>Adicionar Produto</h2>
        <v-form @submit.prevent="submitForm">
          <v-text-field label="Nome" v-model="produto.nome" required></v-text-field>
          <v-text-field label="Descrição" v-model="produto.descricao" required></v-text-field>
          <v-text-field label="Preço" v-model="produto.preco" type="number" required></v-text-field>
          <v-text-field label="Quantidade" v-model="produto.quantidade" type="number" required></v-text-field>
          <v-text-field label="Categoria" v-model="produto.categoria" required></v-text-field>
          <div class="btn">
            <v-btn type="submit" color="primary">Adicionar Produto</v-btn>
            <v-btn type="submit" @click="back" color="secondary">Voltar</v-btn>
          </div>
        </v-form>
      </v-col>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { addProduto } from '~/services/apiService'

const router = useRouter()

const produto = ref({
  nome: '',
  descricao: '',
  preco: 0,
  quantidade: 0,
  categoria: '',
})

const back = () => {
  router.push('/')
}

const submitForm = async () => {
  try {
    await addProduto(produto.value)
    alert('Produto adicionado com sucesso!')
    router.push('/')
  } catch (error) {
    console.error('Erro ao adicionar o produto:', error)
    alert('Erro ao adicionar produto. Por favor, tente novamente mais tarde.')
  }
}

</script>

<style scoped>

.btn {
  display: flex;
  justify-content: space-between;
}

h2 {
  margin-bottom: 10px;
}

</style>