<template>
  <v-card>
    <v-row>
      <v-avatar class="ma-3" size="125" tile>
        <v-img contain :src="imgPath"></v-img>
      </v-avatar>
    </v-row>
    <v-card-title class="headline" v-text="inmobiliaria.nombre"></v-card-title>
    <v-card-subtitle v-text="inmobiliaria.direccion +' - '+ inmobiliaria.localidad"></v-card-subtitle>
    <v-expansion-panels>
      <v-expansion-panel>
        <v-expansion-panel-header>Más datos</v-expansion-panel-header>
        <v-expansion-panel-content>
          <v-input prepend-icon="mdi-phone">Teléfono: {{inmobiliaria.telefono}}</v-input>
          <v-input prepend-icon="mdi-web">
            Dirección web:
            <a :href="inmobiliaria.url">{{ inmobiliaria.url}}</a>
          </v-input>
          <v-input prepend-icon="mdi-information">CUIT: {{inmobiliaria.cuit}}</v-input>
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
  </v-card>
</template>

<script>
export default {
  props: ["inmobiliaria"],
  computed: {
    imgPath() {
      var path = "";
      if (this.inmobiliaria) {
        path =
          this.$store.getters.getPathForInmobiliariasImages +
          this.inmobiliaria.id;
      }
      return path;
    },
  },
};
</script>

<style>
</style>