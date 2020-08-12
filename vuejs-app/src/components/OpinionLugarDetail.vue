<template>
  <v-card dark dense outlined shaped>
    <v-card-text>
      <v-row>
        <v-col cols="1">
          <v-icon color="green" cols="2">mdi-comment</v-icon>
        </v-col>
        <v-col cols="11">
          <v-textarea class="mx-2" auto-grow disabled label="Pros" rows="1" v-model="opinion.pros"></v-textarea>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="1">
          <v-icon color="red" cols="2">mdi-comment</v-icon>
        </v-col>
        <v-col cols="11">
          <v-textarea
            class="mx-2"
            disabled
            auto-grow
            label="Contras"
            rows="1"
            v-model="opinion.contras"
          ></v-textarea>
        </v-col>
      </v-row>
      <v-row v-if="opinion.recomiendaLugar">
        <v-col cols="8">
          <v-input>Recomendado</v-input>
        </v-col>
        <v-col cols="2">
          <v-icon color="green">mdi-thumb-up</v-icon>
        </v-col>
      </v-row>

      <v-row v-if="!opinion.recomiendaLugar">
        <v-col cols="8">
          <v-input>No Recomendado</v-input>
        </v-col>
        <v-col cols="2">
          <v-icon color="red">mdi-thumb-down</v-icon>
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  props: ["opinion"],
  data() {
    return {};
  },
};
</script>

<style>
</style>