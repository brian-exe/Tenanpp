<template>
  <v-card dark>
    <v-card-title class="headline">{{opinion.fechaOpinion}}</v-card-title>

    <v-card-subtitle color="#308cd4">{{opinion.comentarioPositivo}}</v-card-subtitle>

    <v-card-actions>
      <v-btn text>{{opinion.aceptaPagoElectronico ? 'ACEPTA' : 'NO ACEPTA'}}</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: ["opinion"]
};
</script>

<style>
</style>