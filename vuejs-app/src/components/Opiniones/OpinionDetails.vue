<template>
  <v-card dark>
    <v-card-title style="background-color:#308cd4" class="headline">
      {{promedioGeneral}}
      <v-rating
        :length="length"
        dense
        size="18"
        v-model="promedioGeneral"
        color="yellow darken-3"
        background-color="grey darken-1"
        empty-icon="mdi-star-outline"
        full-icon="mdi-star"
        half-icon="mdi-star-half-full"
        half-increments
        readonly
      ></v-rating>
    </v-card-title>
    <v-card-subtitle style="background-color:#308cd4">{{opinionDate.toString()}}</v-card-subtitle>
    <v-row>
      <v-col cols="6">
        <v-card-text style="color: white;">
          <v-icon color="success" x-large>mdi-plus</v-icon>
          {{opinion.comentarioPositivo ? opinion.comentarioPositivo : "-"}}
        </v-card-text>
      </v-col>
      <v-col cols="6">
        <v-card-text style="color: white;">
          <v-icon color="error" x-large>mdi-minus</v-icon>
          {{opinion.comentarioNegativo ? opinion.comentarioNegativo : "-"}}
        </v-card-text>
      </v-col>
    </v-row>
    <v-row>
      <v-divider class="mx-4"></v-divider>
    </v-row>
    <v-row>
      <v-col cols="4" class="contentcentered">
        <v-row>
          <v-col cols="12">Valoración Atención</v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            ({{promedioAtencion}})
            <v-rating
              :length="length"
              dense
              size="14"
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
      </v-col>

      <v-col cols="4" class="contentcentered">
        <v-row>
          <v-col cols="12">Valoración Responsabilidad</v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            ({{promedioResponsabilidad}})
            <v-rating
              :length="length"
              dense
              size="14"
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
      </v-col>

      <v-col cols="4" class="contentcentered">
        <v-row>
          <v-col cols="12">Valoración Conducta Ética</v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            ({{promedioConductaEtica}})
            <v-rating
              :length="length"
              dense
              size="14"
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
      </v-col>
    </v-row>
    <v-row>
      <v-divider class="mx-4"></v-divider>
    </v-row>
    <v-row>
      <v-col cols="4">
        <v-input>Acepta pago electrónico:</v-input>
      </v-col>
      <v-col cols="2">
        <v-icon color="success" v-if="opinion.aceptaPagoElectronico">mdi-check</v-icon>
        <v-icon v-else color="red">mdi-window-close</v-icon>
      </v-col>
    </v-row>
  </v-card>
</template>

<script>
export default {
  props: ["opinion"],
  data() {
    return {
      length: 5
    };
  },
  computed: {
    promedioGeneral() {
      var promedio =
        (this.opinion.valoracionConductaEtica +
          this.opinion.valoracionResponsabilidad +
          this.opinion.valoracionAtencion) /
        3;

      return parseFloat(promedio.toFixed(2));
    },
    opinionDate() {
      var date = new Date(this.opinion.fechaOpinion);
      return (
        date.getDate() + "/" + date.getMonth() + "/" + (date.getYear() + 1900)
      );
    },
    promedioAtencion() {
      return this.opinion.valoracionAtencion;
    },
    promedioConductaEtica() {
      return this.opinion.valoracionConductaEtica;
    },
    promedioResponsabilidad() {
      return this.opinion.valoracionResponsabilidad;
    }
  }
};
</script>

<style>
</style>