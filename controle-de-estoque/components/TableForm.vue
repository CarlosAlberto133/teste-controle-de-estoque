<template>
  <div>
    <v-container>
      <v-table height="300px" fixed-header>
        <thead>
          <tr>
            <th class="text-left">Nome</th>
            <th class="text-left">Descrição</th>
            <th class="text-left">Preço</th>
            <th class="text-left">Quantidade</th>
            <th class="text-left">Categoria</th>
            <th class="text-left">Ações</th>
          </tr>
        </thead>
        
        <tbody class="bg-surface-light pt-4">
          <tr v-for="produto in produtos" :key="produto.id" >
            <td>{{ produto.nome }}</td>
            <td>{{ produto.descricao }}</td>
            <td>{{ produto.preco }}</td>
            <td>{{ produto.quantidade }}</td>
            <td>{{ produto.categoria }}</td>
            <td>
              <v-btn color="primary" @click="$emit('edit-produto', produto.id)">Editar</v-btn>
              <v-btn color="secondary" @click="$emit('delete-produto', produto.id)">Excluir</v-btn>
            </td>
          </tr>
        </tbody>
      </v-table>
  </v-container>
  </div>
</template>

<script setup lang="ts">
import type { Produto } from '~/interfaces/Produtos';

const props = defineProps<{ produtos: Produto[] }>()
</script>

<style scoped>

.v-btn {
  margin-right: 5px;
}
</style>
