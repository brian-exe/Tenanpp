<template>
  <v-container color="#308cd4">
    <v-row :justify="'end'">
      <v-col :cols="4">
        <Search></Search>
      </v-col>
    </v-row>
    <v-row>
      <h2>Top 3 Inmobiliarias</h2>
    </v-row>
    <v-card>
      <v-row>
        <v-col :cols="4">
          <InmobiliariaRanking
            rankingTitle="Ranking General"
            :rankingData="inmobiliariasRankings.rankingGeneral"
            fieldForRanking="promedioGeneral"
          ></InmobiliariaRanking>
        </v-col>
        <v-col :cols="4">
          <InmobiliariaRanking
            rankingTitle="Ranking Atencion"
            :rankingData="inmobiliariasRankings.rankingAtencion"
            fieldForRanking="promedioAtencion"
          ></InmobiliariaRanking>
        </v-col>
        <v-col :cols="4">
          <InmobiliariaRanking
            rankingTitle="Ranking Responsabilidad"
            :rankingData="inmobiliariasRankings.rankingResponsabilidad"
            fieldForRanking="promedioResponsabilidad"
          ></InmobiliariaRanking>
        </v-col>
      </v-row>
    </v-card>
  </v-container>
</template>

<script>
import Search from "@/components/Inmobiliarias/SearchInmobiliaria.vue";
import InmobiliariaRanking from "@/components/Inmobiliarias/InmobiliariaRanking.vue";

import { mapState } from "vuex";

export default {
  name: "Inmobiliarias",
  computed: {
    ...mapState(["loadingStatus", "inmobiliariasRankings"])
  },
  components: {
    Search,
    InmobiliariaRanking
  },
  created() {
    this.$store.dispatch("obtainInmobiliariasRankings");
  }
};
</script>

<style></style>
