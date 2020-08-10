<template>
  <v-row>
    <v-spacer></v-spacer>
    <v-col cols="6">
      <v-card>
        <v-img src="../../public/404.jpg"></v-img>
        <v-card-title>No pudimos encontrar lo que buscabas</v-card-title>
        <v-card-subtitle>Por favor comprueba la dirección</v-card-subtitle>
        <v-card-actions>
          <v-btn block :to="{ path: '/'}" dark color="light-blue">Ir al inicio</v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
    <v-spacer></v-spacer>
  </v-row>
</template>

<script>
export default {};
</script>

<style>
</style>