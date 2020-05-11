<template>
    <v-app dark>
        <v-app-bar app dark>
            <div class="d-flex align-center">
                <v-img
                    alt="Vuetify Logo"
                    class="shrink mr-2"
                    contain
                    src="../public/logo_dark.png"
                    transition="scale-transition"
                />
            </div>
            <v-tabs fixed-tabs optional>
                <v-tab to="/inmobiliarias">Inmobiliarias</v-tab>
                <v-tab to="/inmuebles">Inmuebles</v-tab>
            </v-tabs>
        </v-app-bar>
        <v-content>
            <v-container>
                <v-row :justify="'end'">
                    <v-col :cols="4">
                        <v-text-field
                            hide-details
                            prepend-icon="mdi-magnify"
                            single-line
                        ></v-text-field
                    ></v-col>
                </v-row>
            </v-container>
            <router-view></router-view>
        </v-content>
    </v-app>
</template>

<script>
    export default {
        name: 'App',
        data: () => ({
            //
        })
    };
</script>
