<template>
  <v-container>
    <v-row :justify="'end'">
      <v-col :cols="4">
        <Search></Search>
      </v-col>
    </v-row>
    <v-row>
      <v-col :cols="12">
        <InmobiliariaHeader></InmobiliariaHeader>
      </v-col>
    </v-row>
    <v-row>
      <v-col :cols="12" v-for="opinion in currentInmobiliariaOpiniones" :key="opinion.id">
        <OpinionDetails :opinion="opinion"></OpinionDetails>
      </v-col>
    </v-row>
    <v-card></v-card>
    <v-btn absolute dark bottom right rounded color="light-blue">Agregar calificación</v-btn>
  </v-container>
</template>

<script>
import Search from "@/components/Inmobiliarias/SearchInmobiliaria.vue";
import InmobiliariaHeader from "@/components/Inmobiliarias/InmobiliariaHeader.vue";
import OpinionDetails from "@/components/Opiniones/OpinionDetails.vue";

import { mapState } from "vuex";

export default {
  props: ["id"],
  components: {
    Search,
    InmobiliariaHeader,
    OpinionDetails
  },
  computed: {
    ...mapState([
      "currentInmobiliaria",
      "currentInmobiliariaOpiniones",
      "currentInmobiliariaEstadisticas"
    ])
  },
  created() {
    this.$store.dispatch("getInmobiliaria", this.id);
    this.$store.dispatch("obtainOpinionesForInmobiliaria", this.id);
    this.$store.dispatch("obtainEstadisticasForInmobiliaria", this.id);
  }
};
</script>

<style>
</style>