<template>
  <v-container>
    <v-row>
      <v-col cols="6">
        <v-card>
          <v-card-title>Ingrese la direccion</v-card-title>
          <v-card-text>
            <gmap-autocomplete
              @place_changed="setPlace"
              placeholder="Escriba la direccion..."
              style="width:100%"
            ></gmap-autocomplete>
          </v-card-text>

          <label></label>
        </v-card>
      </v-col>
      <v-spacer></v-spacer>
      <v-col cols="5">
        <v-card>
          <v-row justify="center">
            <v-dialog :disabled="!enabledAddOpinion" v-model="dialog" persistent max-width="600px">
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  block
                  :color="enabledAddOpinion ? 'primary' : 'grey'"
                  dark
                  v-bind="attrs"
                  v-on="on"
                >Agregar opinion sobre este lugar</v-btn>
              </template>
              <v-card>
                <v-card-title>
                  <span class="headline">Opinion</span>
                </v-card-title>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12">
                        <v-textarea
                          :rules="areaRules"
                          filled
                          :counter="areaLength"
                          label="Pros"
                          v-model="pros"
                          background-color="light-green"
                        ></v-textarea>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12">
                        <v-textarea
                          :rules="areaRules"
                          filled
                          :counter="areaLength"
                          label="Contras"
                          v-model="contras"
                          background-color="red"
                        ></v-textarea>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="10">
                        <v-select
                          :items="opcionesRecomiendaLugar"
                          item-value="value"
                          item-text="text"
                          v-model="recomiendaLugar"
                          filled
                          label="¿Recomendaria usted este lugar para vivir?"
                        ></v-select>
                      </v-col>
                      <v-col cols="2">
                        <v-icon v-if="recomiendaLugar" color="green">mdi-thumb-up</v-icon>
                        <v-icon v-if="!recomiendaLugar" color="red">mdi-thumb-down</v-icon>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-alert
                        v-if="!success"
                        border="right"
                        colored-border
                        type="error"
                        elevation="2"
                      >Error, no se pudo agregar la opinion</v-alert>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="error" text @click="closeDialog()">Cerrar</v-btn>
                  <v-btn color="primary" text @click="guardarOpinion()">Guardar</v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="6">
        <v-card>
          <gmap-map :center="center" :zoom="zoom" style="height:400px; width:100%">
            <gmap-marker
              :key="index"
              v-for="(m, index) in markers"
              :position="m.position"
              @click="markerFocused(m)"
            ></gmap-marker>
          </gmap-map>
        </v-card>
      </v-col>
      <v-spacer></v-spacer>
      <v-col cols="5" v-if="hayOpiniones">
        <OpinionLugarDetail v-for="(opinion, index) in opiniones" :opinion="opinion" :key="index"></OpinionLugarDetail>
      </v-col>
      <v-col cols="5" v-if="!hayOpiniones && hayMarcadorSeleccionado">
        <v-card>
          <v-card-text>No se encontraron opiniones para este lugar</v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import LugaresService from "@/services/LugaresService.js";
import OpinionLugarDetail from "@/components/OpinionLugarDetail.vue";

export default {
  name: "GoogleMap",
  components: {
    OpinionLugarDetail,
  },
  data() {
    return {
      //Capital Federal
      center: { lat: -34.599411, lng: -58.443509 },
      markers: [],
      places: [],
      enabledAddOpinion: false,
      currentPlace: null,
      textBtn: "",
      zoom: 12,
      currentMarker: {},
      areaRules: [
        (v) => !!v || "El campo es obligatorio",
        (v) =>
          (v && v.length <= this.areaLength) ||
          "No se permiten mas de " + this.areaLength + " caracteres",
      ],
      areaLength: 250,
      pros: "",
      contras: "",
      valid: false,
      dialog: false,
      opcionesRecomiendaLugar: [
        {
          text: "SI",
          value: true,
        },
        { text: "NO", value: false },
      ],
      recomiendaLugar: false,
      success: null,
      opiniones: [],
      lugaresCercanos: [],
    };
  },
  computed: {
    hayOpiniones() {
      return this.currentMarker != null && this.opiniones.length > 0;
    },
    hayMarcadorSeleccionado() {
      return this.currentMarker != {};
    },
  },
  mounted() {
    this.geolocate();
  },

  methods: {
    closeDialog() {
      this.dialog = false;
      this.cleanDialog();
    },
    guardarOpinion() {
      var payload = {
        lugar: {
          latitude: this.currentMarker.position.lat,
          longitude: this.currentMarker.position.lng,
          direccion: this.currentMarker.position.address,
        },
        opinion: {
          pros: this.pros,
          contras: this.contras,
          recomiendaLugar: this.recomiendaLugar,
        },
      };
      LugaresService.addOpinion(payload)
        .then(() => {
          this.success = true;
          this.dialog = false;
          this.cleanDialog();
          this.loadOpiniones();
        })
        .catch((err) => {
          console.log(err);
          this.success = false;
        });
    },
    cleanDialog() {
      this.pros = "";
      this.contras = "";
      this.recomiendaLugar = false;
      this.success = true;
    },
    markerFocused(marker) {
      this.currentMarker = marker;
      this.center = marker.position;
      this.enabledAddOpinion = true;
      this.loadOpiniones();
      this.loadLugaresCercanos();
    },
    loadLugaresCercanos() {
      var payload = {
        latitude: this.currentMarker.position.lat,
        longitude: this.currentMarker.position.lng,
        direccion: this.currentMarker.position.address,
      };

      LugaresService.getLugaresCercanos(payload)
        .then((res) => {
          this.success = true;
          //console.log(res.data.data);
          this.lugaresCercanos = res.data.data;
          this.updateMarkers();
        })
        .catch((err) => {
          console.log(err);
        });
    },
    updateMarkers() {
      this.lugaresCercanos.forEach((lugar) => {
        const marker = {
          lat: lugar.latitude,
          lng: lugar.longitude,
          address: lugar.direccion,
        };
        this.markers.push({ position: marker });
      });
    },
    loadOpiniones() {
      var payload = {
        direccion: this.currentMarker.position.address,
      };
      //console.log(payload);
      LugaresService.getOpinionesFor(payload)
        .then((res) => {
          this.success = true;
          //console.log(res.data.data);
          this.opiniones = res.data.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    // receives a place object via the autocomplete component
    setPlace(place) {
      //console.log(place);
      this.currentPlace = place;
      this.addMarker();
    },
    addMarker() {
      if (this.currentPlace) {
        const marker = {
          lat: this.currentPlace.geometry.location.lat(),
          lng: this.currentPlace.geometry.location.lng(),
          address: this.currentPlace.formatted_address,
        };
        //console.log(marker);

        this.currentMarker = { position: marker };
        this.markerFocused(this.currentMarker);
        this.markers.push({ position: marker });
        this.places.push(this.currentPlace);
        this.center = marker;
        this.zoom = this.zoom + 2;

        this.currentPlace = null;
      }
    },
    geolocate: function () {
      navigator.geolocation.getCurrentPosition((position) => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude,
        };
      });
    },
  },
};
</script>
