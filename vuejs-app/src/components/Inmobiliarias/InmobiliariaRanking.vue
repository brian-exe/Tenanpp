<template>
  <v-card dark>
    <v-card-title style="background-color:#308cd4">{{rankingTitle}}</v-card-title>
    <v-list class="transparent">
      <v-list-item v-for="(item, i) in rankingData" :key="i">
        <v-list-item-title>
          <v-card-actions>
            <v-btn @click="goToInmobiliariaDetail(item.inmobiliariaId)">
              <strong
                v-if="(i+1) ==1"
              >{{i+1}} ({{item[fieldForRanking].toFixed(2)}}) {{ item.nombre }}</strong>
              <template v-else>{{i+1}} ({{item[fieldForRanking].toFixed(2)}}) {{ item.nombre }}</template>
            </v-btn>
          </v-card-actions>
        </v-list-item-title>
        <!-- 
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>-->
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
//import { mapState } from "vuex";

export default {
  computed: {},
  props: ["rankingTitle", "rankingData", "fieldForRanking"],
  methods: {
    goToInmobiliariaDetail(id) {
      this.$router.push({
        name: "InmobiliariaDetail",
        params: { id: id }
      });
    }
  }
};
</script>

<style>
</style>