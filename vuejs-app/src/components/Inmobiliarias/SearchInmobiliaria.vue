<template>
  <v-autocomplete
    v-model="select"
    :loading="loadingStatus"
    :items="searchInmobiliariaResult"
    :search-input.sync="search"
    class="mx-4"
    flat
    item-text="nombre"
    item-value="id"
    hide-details
    hide-no-data
    clearable
    @input="inputChanged"
    :label="this.placeholder"
    prepend-icon="mdi-magnify"
  ></v-autocomplete>
</template>

<script>
//import Service from "@/services/InmobiliariasService";
import { mapState } from "vuex";

export default {
  data() {
    return {
      placeholder: "Buscar Inmobiliaria",
      loading: false,
      items: [],
      search: null,
      select: null
    };
  },
  computed: {
    ...mapState(["loadingStatus", "searchInmobiliariaResult"])
  },
  watch: {
    search(val) {
      val && val.length >= 3 && this.querySelections(val);
    }
  },
  methods: {
    inputChanged() {
      //this.$router.push({ path: `/inmobiliarias/${this.select.id}` });
      if (this.select) {
        this.$router.push({
          name: "InmobiliariaDetail",
          params: { id: this.select }
        });
      }
    },
    querySelections(v) {
      this.$store.dispatch("searchInmobiliaria", v);
    }
  }
};
</script>