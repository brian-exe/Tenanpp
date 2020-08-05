<template>
  <v-container>
    <v-row :justify="'end'">
      <v-col :cols="4">
        <Search></Search>
      </v-col>
    </v-row>
    <v-card></v-card>
  </v-container>
</template>

<script>
import Search from "@/components/Inmobiliarias/SearchInmobiliaria.vue";
import { mapState } from "vuex";

export default {
  name: "Inmobiliarias",
  computed: {
    ...mapState(["loadingStatus"])
  },
  components: {
    Search
  }
};
</script>

<style></style>
