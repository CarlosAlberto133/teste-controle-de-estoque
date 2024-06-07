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

    <TableForm :produtos="produtosFiltrados" @edit-produto="editProduto" @delete-produto="handleDeleteProduto" />
  
    <v-container align="center">
      <v-card
        width="200"
      >
        <template v-slot:title>
          <span class="font-weight-black">Total Produtos</span>
        </template>

        <v-card-text class="bg-surface-light pt-4">
          {{ totalProdutos }}
        </v-card-text>
      </v-card>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue'
import { getEstoque, deleteProduto } from '~/services/apiService'
import type { Produto } from '~/interfaces/Produtos'

const produtos = ref<Produto[]>([])
const filtroSelecionado = ref<string>('Nome')
const termoPesquisa = ref<string>('')
const opcoesFiltro = ['Nome', 'Categoria']

const router = useRouter()

onMounted(async () => {
  try {
    produtos.value = await getEstoque()
  } catch (error) {
    console.error('Erro ao carregar os produtos:', error)
  }
})

const produtosFiltrados = computed(() => {
  if (!termoPesquisa.value) return produtos.value
  return produtos.value.filter(produto => {
    if (filtroSelecionado.value === 'Nome') {
      return produto.nome.toLowerCase().includes(termoPesquisa.value.toLowerCase())
    } else if (filtroSelecionado.value === 'Categoria') {
      return produto.categoria.toLowerCase().includes(termoPesquisa.value.toLowerCase())
    }
    return true
  })
})

const totalProdutos = computed(() => produtosFiltrados.value.length)

const editProduto = (id: number) => {
  router.push(`/Edit/${[id]}`)
}

const handleDeleteProduto = async (id: number) => {
  try {
    const success = await deleteProduto(id)
    if (success) {
      produtos.value = produtos.value.filter(produto => produto.id !== id)
      alert('Produto excluído com sucesso')
    }
  } catch (error) {
    alert('Erro ao excluir o produto. Por favor, tente novamente.')
  }
}

</script>

<style scoped>



</style>