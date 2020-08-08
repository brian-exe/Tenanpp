<template>
  <v-row>
    <v-col cols="7">
      <v-card>
        <v-row>
          <v-avatar class="ma-3" size="125" tile>
            <v-img :src="imgPath"></v-img>
          </v-avatar>
        </v-row>
        <v-card-title class="headline" v-text="currentInmobiliaria.nombre"></v-card-title>

        <v-card-subtitle
          v-text="currentInmobiliaria.direccion +' - '+ currentInmobiliaria.localidad"
        ></v-card-subtitle>
        <v-expansion-panels>
          <v-expansion-panel>
            <v-expansion-panel-header>Mas datos</v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-input prepend-icon="mdi-phone">Telefono: {{currentInmobiliaria.telefono}}</v-input>
              <v-input prepend-icon="mdi-web">
                Dirección web:
                <a :href="currentInmobiliaria.url">{{ currentInmobiliaria.url}}</a>
              </v-input>
              <v-input prepend-icon="mdi-information">CUIT: {{currentInmobiliaria.cuit}}</v-input>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-card>
    </v-col>
    <v-col cols="5">
      <v-card>
        <v-row>
          <v-col cols="5" style="align-self: center;text-align: end">
            <span>General ({{promedioGeneral}})</span>
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
            <span>Pago Electronico</span>
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
            <v-expansion-panel-header>Mas</v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-row>
                <v-col cols="5" style="align-self: center;text-align: end">
                  <span>Atencion ({{promedioAtencion}})</span>
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
                  <span>Responsabilidad ({{promedioResponsabilidad}})</span>
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
                  <span>Conducta Etica ({{promedioConductaEtica}})</span>
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

export default {
  name: "InmobiliariaHeader",
  data() {
    return {
      length: 5,
      show: false
    };
  },
  computed: {
    ...mapState(["currentInmobiliaria", "currentInmobiliariaEstadisticas"]),
    promedioGeneral() {
      return (
        (this.currentInmobiliariaEstadisticas.promedioAtencion +
          this.currentInmobiliariaEstadisticas.promedioConductaEtica +
          this.currentInmobiliariaEstadisticas.promedioResponsabilidad) /
        3
      ).toFixed(2);
    },
    promedioAtencion() {
      return this.currentInmobiliariaEstadisticas.promedioAtencion;
    },
    promedioConductaEtica() {
      return this.currentInmobiliariaEstadisticas.promedioConductaEtica;
    },
    promedioResponsabilidad() {
      return this.currentInmobiliariaEstadisticas.promedioResponsabilidad;
    },
    votosPagoElectronico() {
      return this.currentInmobiliariaEstadisticas.votosPagoElectronico;
    },
    votosNoPagoElectronico() {
      return this.currentInmobiliariaEstadisticas.votosNoPagoElectronico;
    },
    porcentajeVotos() {
      return (
        (this.votosPagoElectronico * 100) /
        (this.votosPagoElectronico + this.votosNoPagoElectronico)
      );
    },
    imgPath() {
      return (
        this.$store.getters.getPathForInmobiliariasImages +
        this.currentInmobiliaria.id
      );
    }
  },
  created() {
    //this.$store.dispatch();
  }
};
</script>

<style>
</style>