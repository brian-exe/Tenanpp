<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <InmobiliariaData :inmobiliaria="currentInmobiliaria"></InmobiliariaData>
      </v-col>
    </v-row>
    <v-row></v-row>
    <v-row justify="center" align="center">
      <v-spacer></v-spacer>
      <v-col cols="6">
        <v-card>
          <v-col>
            <h1>Agregar opinion</h1>
          </v-col>
          <v-form v-model="valid">
            <v-container>
              <v-row>
                <v-divider class="mx-4"></v-divider>
              </v-row>
              <v-row class="contentcentered">
                <v-col cols="4">
                  <v-input>Valoración Atención</v-input>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="promedioAtencion"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    half-icon="mdi-star-half-full"
                    half-increments
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>

              <v-row class="contentcentered">
                <v-col cols="4">
                  <v-input>Valoración Atención</v-input>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="promedioAtencion"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    half-icon="mdi-star-half-full"
                    half-increments
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>

              <v-row class="contentcentered">
                <v-col cols="4">
                  <v-input>Valoración Atención</v-input>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="promedioAtencion"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    half-icon="mdi-star-half-full"
                    half-increments
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-textarea filled auto-grow label="Aspectos positivos" shaped></v-textarea>
                </v-col>
              </v-row>

              <v-row>
                <v-col cols="12">
                  <v-textarea filled auto-grow label="Aspectos negativos" shaped></v-textarea>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-checkbox
                    v-model="checkbox"
                    label="¿La inmobiliaria acepta pago electronico?"
                    required
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-btn block color="#308cd4" @click="submit">Aceptar</v-btn>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </v-card>
      </v-col>
      <v-spacer></v-spacer>
    </v-row>
  </v-container>
</template>

<script>
import InmobiliariaData from "@/components/Inmobiliarias/InmobiliariaData.vue";
import { mapState } from "vuex";
export default {
  props: ["id"],
  components: {
    InmobiliariaData
  },
  computed: {
    ...mapState(["currentInmobiliaria"])
  },
  data() {
    return {
      ValoracionAtencion: 1,
      ValoracionConductaEtica: 1,
      ValoracionResponsabilidad: 1,
      ComentarioNegativo: "",
      ComentarioPositivo: "",
      AceptaPagoElectronico: false
    };
  },
  created() {
    this.$store.dispatch("getInmobiliaria", this.id);
  }
};
</script>

<style>
</style>