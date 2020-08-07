<template>
  <v-app dark>
    <v-app-bar app dark>
      <div class="d-flex align-center">
        <router-link to="/">
          <v-img
            alt="Vuetify Logo"
            class="shrink mr-2"
            contain
            src="../public/logo_dark.png"
            transition="scale-transition"
          />
        </router-link>
      </div>
      <v-tabs fixed-tabs optional>
        <v-tab to="/inmobiliarias">Inmobiliarias</v-tab>
        <v-tab to="/inmuebles">Inmuebles</v-tab>
      </v-tabs>
    </v-app-bar>
    <v-content>
      <router-view :key="$route.path"></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "App",
  data: () => ({
    //
  })
};
</script>
