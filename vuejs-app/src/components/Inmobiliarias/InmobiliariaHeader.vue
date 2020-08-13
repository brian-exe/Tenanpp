<template>
  <v-row>
    <v-col cols="7">
      <InmobiliariaData :inmobiliaria="currentInmobiliaria"></InmobiliariaData>
    </v-col>
    <v-col cols="5">
      <v-card>
        <v-row>
          <v-col cols="5" style="align-self: center;text-align: end">
            <span>General ({{promedioGeneral ? promedioGeneral : 0}})</span>
          </v-col>
          <v-col cols="7">
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
        <v-row>
          <v-col cols="5" style="align-self: center;text-align: end">
            <span>Pago Electrónico</span>
          </v-col>
          <v-col cols="7">
            <v-row justify="space-around">
              <v-col cols="2">
                <v-icon color="success">mdi-thumb-up</v-icon>
              </v-col>
              <v-col cols="8">
                <v-tooltip bottom>
                  <template v-slot:activator="{ on, attrs }">
                    <v-progress-linear
                      v-on="on"
                      v-bind="attrs"
                      height="15"
                      background-color="error"
                      color="success"
                      :value="porcentajeVotos"
                    ></v-progress-linear>
                  </template>
                  <span>{{votosPagoElectronico}} Votos positivos / {{votosNoPagoElectronico}} Votos negativos</span>
                </v-tooltip>
              </v-col>
              <v-col cols="2">
                <v-icon color="error">mdi-thumb-down</v-icon>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
        <v-expansion-panels>
          <v-expansion-panel>
            <v-expansion-panel-header>Más</v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-row>
                <v-col cols="5" style="align-self: center;text-align: end">
                  <span>Atención ({{promedioAtencion ? promedioAtencion : 0}})</span>
                </v-col>
                <v-col cols="7">
                  <v-rating
                    :length="length"
                    v-model="promedioAtencion"
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
              <v-row>
                <v-col cols="5" style="align-self: center;text-align: end">
                  <span>Responsabilidad ({{promedioResponsabilidad ? promedioResponsabilidad : 0}})</span>
                </v-col>
                <v-col cols="7">
                  <v-rating
                    :length="length"
                    v-model="promedioResponsabilidad"
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
              <v-row>
                <v-col cols="5" style="align-self: center;text-align: end">
                  <span>Conducta Ética ({{promedioConductaEtica ? promedioConductaEtica : 0}})</span>
                </v-col>
                <v-col cols="7">
                  <v-rating
                    :length="length"
                    v-model="promedioConductaEtica"
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
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-card>
    </v-col>
  </v-row>
</template>
<script>
import { mapState } from "vuex";
import InmobiliariaData from "@/components/Inmobiliarias/InmobiliariaData.vue";

export default {
  name: "InmobiliariaHeader",
  data() {
    return {
      length: 5,
      show: false,
    };
  },
  components: {
    InmobiliariaData,
  },
  computed: {
    ...mapState(["currentInmobiliaria", "currentInmobiliariaEstadisticas"]),
    promedioGeneral() {
      if (!this.currentInmobiliariaEstadisticas) {
        return 0;
      }
      var result = (
        (this.currentInmobiliariaEstadisticas.promedioAtencion +
          this.currentInmobiliariaEstadisticas.promedioConductaEtica +
          this.currentInmobiliariaEstadisticas.promedioResponsabilidad) /
        3
      ).toFixed(2);

      return parseFloat(result);
    },
    promedioAtencion() {
      if (this.currentInmobiliariaEstadisticas) {
        return this.currentInmobiliariaEstadisticas.promedioAtencion;
      }
      return 0;
    },
    promedioConductaEtica() {
      if (this.currentInmobiliariaEstadisticas) {
        return this.currentInmobiliariaEstadisticas.promedioConductaEtica;
      }
      return 0;
    },
    promedioResponsabilidad() {
      if (this.currentInmobiliariaEstadisticas) {
        return this.currentInmobiliariaEstadisticas.promedioResponsabilidad;
      }
      return 0;
    },
    votosPagoElectronico() {
      if (this.currentInmobiliariaEstadisticas) {
        return this.currentInmobiliariaEstadisticas.votosPagoElectronico;
      }
      return 0;
    },
    votosNoPagoElectronico() {
      if (this.currentInmobiliariaEstadisticas) {
        return this.currentInmobiliariaEstadisticas.votosNoPagoElectronico;
      }
      return 0;
    },
    porcentajeVotos() {
      return (
        (this.votosPagoElectronico * 100) /
        (this.votosPagoElectronico + this.votosNoPagoElectronico)
      );
    },
  },
  created() {
    //this.$store.dispatch();
  },
};
</script>

<style>
</style>