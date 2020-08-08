<template>
  <v-row>
    <v-col :cols="2" justify="space-around">
      <v-img :src="imgPath"></v-img>
    </v-col>
    <v-col :cols="7">
      <h3>{{currentInmobiliaria.nombre}}</h3>
      <h4>{{currentInmobiliaria.direccion}} - {{currentInmobiliaria.localidad}}</h4>
    </v-col>
    <v-col :cols="3" :justify="'end'">
      <span>({{promedioGeneral}})</span>
      <v-rating
        :length="length"
        v-model="promedioGeneral"
        color="yellow darken-3"
        background-color="grey darken-1"
        empty-icon="mdi-star-outline"
        full-icon="mdi-star"
        half-icon="mdi-star-half-full"
        half-increments
        readonly
      ></v-rating>
    </v-col>
  </v-row>
</template>
<script>
import { mapState } from "vuex";

export default {
  name: "InmobiliariaHeader",
  data() {
    return {
      length: 5
    };
  },
  computed: {
    ...mapState(["currentInmobiliaria", "currentInmobiliariaEstadisticas"]),
    promedioGeneral() {
      if (this.currentInmobiliariaEstadisticas) {
        return (
          (this.currentInmobiliariaEstadisticas.promedioAtencion +
            this.currentInmobiliariaEstadisticas.promedioConductaEtica +
            this.currentInmobiliariaEstadisticas.promedioResponsabilidad) /
          3
        ).toFixed(2);
      } else {
        return 0;
      }
    },
    imgPath() {
      return (
        this.$store.getters.getPathForInmobiliariasImages +
        this.currentInmobiliaria.id
      );
    }
  },
  created() {
    //this.$store.dispatch();
  }
};
</script>

<style>
</style>