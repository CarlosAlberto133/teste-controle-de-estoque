<template>
  <div class="fill-height">
    <v-app>
      <Header />
        <slot />
    </v-app>
  </div>
</template>

<script setup lang="ts">

</script>

<style scoped>

.fill-height {
  min-height: 100vh;
}

</style>