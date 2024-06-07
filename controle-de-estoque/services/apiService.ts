import axios from 'axios'
import type { Produto } from '~/interfaces/Produtos'

const apiClient = axios.create({
  baseURL: 'https://localhost:7269/api',
  headers: {
    'Content-Type': 'application/json',
  },
})

export const getEstoque = async () => {
  try {
    const response = await apiClient.get('/estoque')
    return response.data
  } catch (error) {
    console.error('Erro ao carregar os produtos:', error)
    throw error
  }
}

export const deleteProduto = async (id: number) => {
  try {
    await apiClient.delete(`/estoque/${id}`)
    return true
  } catch (error) {
    console.error('Erro ao excluir o produto:', error)
    throw error
  }
}

export const addProduto = async (produto: any) => {
  try {
    const response = await apiClient.post('/estoque', produto)
    return response.data
  } catch (error) {
    console.error('Erro ao adicionar o produto:', error)
    throw error
  }
}

export const getProdutoById = (id: number) => {
  return apiClient.get<Produto>(`/estoque/${id}`)
}

export const updateProduto = (id: number, produto: Produto) => {
  return apiClient.put(`/estoque/${id}`, produto)
}