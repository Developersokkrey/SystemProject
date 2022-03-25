<template>
  <div class="text-center">
    <h1 class="text-3xl font-bold underline">
    Hello world!
  </h1>
    <v-btn dark
           color="orange darken-2"
           @click="snackbar_success = true">
      Open Snackbar Success
    </v-btn>
    <v-btn dark
           color="orange darken-2"
           @click="snackbar_error = true">
      Open Snackbar Error
    </v-btn>

    <v-snackbar v-model="snackbar_success"
                right
                color="success"
                outlined
                shaped
                text
                :timeout="timeout">
      {{ text }}<br />
      {{ text1 }}
      <template v-slot:action="{ attrs }">
        <v-btn color="success"
               text
               v-bind="attrs"
               @click="snackbar_success = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar_error"
                right
                color="error"
                outlined
                shaped
                text
                ransition
                :timeout="timeout">
      {{ text }}
      <template v-slot:action="{ attrs }">
        <v-btn color="error"
               text
               v-bind="attrs"
               @click="snackbar_error = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-alert width="400" type="success" right>
      I'm a success alert.
    </v-alert>
  </div>
  
</template>
<script>
  export default {
    data: () => ({
      snackbar_success: true,
      snackbar_error: false,
      text: 'My timeout is set to success.',
      text1: 'My timeout is set to success1.',
      timeout: 10000,
    }),
  }
</script>
