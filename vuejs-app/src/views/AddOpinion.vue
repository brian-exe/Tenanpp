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
                  <v-row>
                    <v-col cols="2">
                      <v-tooltip bottom>
                        <template v-slot:activator="{ on, attrs }">
                          <v-icon v-on="on" v-bind="attrs">mdi-information</v-icon>
                        </template>
                        <span>Calidad de la atencion de sus integrantes y disposicion a la resolucion de problemas</span>
                      </v-tooltip>
                    </v-col>
                    <v-col cols="10">
                      <v-input>Valoración Atencion</v-input>
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="ValoracionAtencion"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>

              <v-row class="contentcentered">
                <v-col cols="4">
                  <v-row>
                    <v-col cols="2">
                      <v-tooltip bottom>
                        <template v-slot:activator="{ on, attrs }">
                          <v-icon v-on="on" v-bind="attrs">mdi-information</v-icon>
                        </template>
                        <span>
                          Responsabilidad por parte de la inmibiliaria
                          a la hora hacerse cargo de los problemas e intentar solucionarlos
                        </span>
                      </v-tooltip>
                    </v-col>
                    <v-col cols="10">
                      <v-input>Valoración Responsabilidad</v-input>
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="ValoracionResponsabilidad"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>

              <v-row class="contentcentered">
                <v-col cols="4">
                  <v-row>
                    <v-col cols="2">
                      <v-tooltip bottom>
                        <template v-slot:activator="{ on, attrs }">
                          <v-icon v-on="on" v-bind="attrs">mdi-information</v-icon>
                        </template>
                        <span>Conducta en la que la inmobiliaria se dirige respecto a temas legales y/o de caracter ético</span>
                      </v-tooltip>
                    </v-col>
                    <v-col cols="10">
                      <v-input>Valoración Conducta Etica</v-input>
                    </v-col>
                  </v-row>
                </v-col>
                <v-col cols="8">
                  <v-rating
                    dense
                    :length="length"
                    v-model="ValoracionConductaEtica"
                    color="yellow darken-3"
                    background-color="grey darken-1"
                    empty-icon="mdi-star-outline"
                    full-icon="mdi-star"
                    hover
                    large
                  ></v-rating>
                </v-col>
              </v-row>

              <v-row>
                <v-col cols="12">
                  <v-textarea
                    :rules="areaRules"
                    filled
                    :counter="areaLength"
                    auto-grow
                    label="Aspectos positivos"
                    v-model="ComentarioPositivo"
                    shaped
                    aria-required
                  ></v-textarea>
                </v-col>
              </v-row>

              <v-row>
                <v-col cols="12">
                  <v-textarea
                    :rules="areaRules"
                    filled
                    :counter="areaLength"
                    auto-grow
                    label="Aspectos negativos"
                    shaped
                    v-model="ComentarioNegativo"
                  ></v-textarea>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-select
                    :items="opcionesPagoElectronico"
                    item-value="value"
                    item-text="text"
                    v-model="AceptaPagoElectronico"
                    filled
                    label="¿La inmobiliaria acepta pago electronico?"
                  ></v-select>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="12">
                  <v-btn block color="#308cd4" @click="submit">Aceptar</v-btn>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
          <v-alert
            v-model="showAlert"
            border="right"
            colored-border
            type="error"
            elevation="2"
          >{{textAlert}}</v-alert>
        </v-card>
      </v-col>
      <v-spacer></v-spacer>
    </v-row>
  </v-container>
</template>

<script>
import InmobiliariaData from "@/components/Inmobiliarias/InmobiliariaData.vue";
import { mapState } from "vuex";
import OpinionesService from "@/services/OpinionesService";

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
      valid: false,
      ValoracionAtencion: 1,
      ValoracionConductaEtica: 1,
      ValoracionResponsabilidad: 1,
      ComentarioNegativo: "",
      ComentarioPositivo: "",
      AceptaPagoElectronico: false,
      areaLength: 500,
      length: 5,
      showAlert: false,
      textAlert: "",
      opcionesPagoElectronico: [
        {
          text: "SI",
          value: true
        },
        { text: "NO", value: false }
      ],
      areaRules: [
        v => !!v || "El campo es obligatorio",
        v =>
          (v && v.length <= this.areaLength) ||
          "No se permiten mas de " + this.areaLength + " caracteres"
      ]
    };
  },
  watch: {
    currentInmobiliaria: function(value) {
      if (!value) {
        this.$router.push({ name: "NotFound" });
      }
    }
  },
  created() {
    this.$store.dispatch("getInmobiliaria", this.id);
  },
  methods: {
    submit() {
      if (this.valid) {
        var payload = {
          ValoracionAtencion: this.ValoracionAtencion,
          ValoracionConductaEtica: this.ValoracionConductaEtica,
          ValoracionResponsabilidad: this.ValoracionResponsabilidad,
          ComentarioNegativo: this.ComentarioNegativo,
          ComentarioPositivo: this.ComentarioPositivo,
          AceptaPagoElectronico: this.AceptaPagoElectronico
        };
        console.log(payload);
        OpinionesService.addOpinion(this.id, payload)
          .then(res => {
            this.$router.push({ name: "Inmobiliarias" });
            console.log(res);
          })
          .catch(err => {
            console.log(err.message);
            if (err.response.data.message) {
              this.showAlert = true;
              this.textAlert = err.response.data.message;
            }
          });
      }
    }
  }
};
</script>

<style>
</style>