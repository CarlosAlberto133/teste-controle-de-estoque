<template>
  <div>
    <v-container>
      <v-col cols="12">
        <h2>Editar Produto</h2>
        <v-form @submit.prevent="submitForm">
          <v-text-field label="Nome" v-model="produto.nome" required></v-text-field>
          <v-text-field label="Descrição" v-model="produto.descricao" required></v-text-field>
          <v-text-field label="Preço" v-model="produto.preco" type="number" required></v-text-field>
          <v-text-field label="Quantidade" v-model="produto.quantidade" type="number" required></v-text-field>
          <v-text-field label="Categoria" v-model="produto.categoria" required></v-text-field>
          <div class="btn">
            <v-btn type="submit" color="primary">Salvar Alterações</v-btn>
            <v-btn type="button" @click="back" color="secondary">Voltar</v-btn>
          </div>
        </v-form>
      </v-col>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { useRoute, useRouter } from 'vue-router'
import { getProdutoById, updateProduto } from '~/services/apiService'
import type { Produto } from '~/interfaces/Produtos'

const route = useRoute()
const router = useRouter()

const produto = ref<Produto>({
  id: 0,
  nome: '',
  descricao: '',
  preco: 0,
  quantidade: 0,
  categoria: '',
})

const back = () => {
  router.push('/')
}

onMounted(async () => {
  const id = Number(route.params.id)
  if (!isNaN(id)) {
    try {
      const response = await getProdutoById(id)
      produto.value = response.data
    } catch (error) {
      console.error('Erro ao carregar o produto:', error)
    }
  }
})

const submitForm = async () => {
  try {
    await updateProduto(produto.value.id, produto.value)
    alert('Produto atualizado com sucesso!')
    router.push('/')
  } catch (error) {
    console.error('Erro ao atualizar o produto:', error)
    alert('Erro ao atualizar produto. Por favor, tente novamente mais tarde.')
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