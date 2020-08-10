<template>
  <v-container fluid>
    <p>Inmuebles</p>
  </v-container>
</template>

<script>
import gmapsInit from "@/utils/gmaps";

export default {
  name: "Inmuebles",
  async mounted() {
    try {
      const google = await gmapsInit();
      const geocoder = new google.maps.Geocoder();
      const map = new google.maps.Map(this.$el);

      geocoder.geocode({ address: "Austria" }, (results, status) => {
        if (status !== "OK" || !results[0]) {
          throw new Error(status);
        }

        map.setCenter(results[0].geometry.location);
        map.fitBounds(results[0].geometry.viewport);
      });
    } catch (error) {
      console.error(error);
    }
  }
};
</script>

<style></style>
