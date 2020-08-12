<template>
  <v-container fluid>
    <google-map />
  </v-container>
</template>

<script>
import GoogleMap from "@/components/GoogleMap";

export default {
  name: "Lugares",
  components: {
    GoogleMap,
  },
};
</script>

<style></style>
