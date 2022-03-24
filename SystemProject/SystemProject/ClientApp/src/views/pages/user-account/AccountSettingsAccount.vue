<template>
  <v-card flat
          class="pa-3 mt-2">
    <v-card-text>
      <v-form class="multi-col-validation mt-6" ref="form">
        <v-row>
          <v-col md="6" cols="12">
            <v-text-field label="Username" dense outlined v-model="UserAccount.username" :rules="inputRules"></v-text-field>
          </v-col>
          <v-col md="6" cols="12">
            <v-text-field label="Password" dense outlined type="Password" v-model="UserAccount.password" :rules="inputRules"></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <v-select dense outlined label="Rule" :items="user_rules" v-model="UserAccount.rule" item-text="title" item-value="rule"></v-select>
          </v-col>
          <v-col cols="12" md="6">
            <v-text-field dense outlined label="Company" v-model="UserAccount.company" :rules="inputRules"></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <p class="text--primary mt-n3 mb-2">
              Gender
            </p>
            <v-radio-group row class="mt-0" hide-details v-model="UserAccount.gender">
              <v-radio value:0 label="Male"></v-radio>
              <v-radio value:1 label="Female"></v-radio>
              <v-radio value:2 label="Other"></v-radio>
            </v-radio-group>
          </v-col>
          <v-col cols="12" md="6">
            <v-select dense outlined label="Status" :items="statuss" v-model="UserAccount.status" item-text="title" item-value="status"></v-select>
          </v-col>
          <!-- tbn save -->
          <v-col cols="12">
            <v-btn color="primary" class="me-3 mt-4" @click.prevent="saveData"> Save changes </v-btn>
            <v-btn color="secondary" outlined class="mt-4" type="reset" @click.prevent="resetForm">  Cancel </v-btn>
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>
  </v-card>  
</template>

<script>
import axios from 'axios'
export default {
  data: () => ({
      statuss: [
                { title: 'Active', status: 0 },
                { title: 'Inactive', status: 1 },
                { title: 'Pending', status: 2 },
                { title: 'Close', status: 3 },                 
            ],
      user_rules: [
                    { title: 'Super Admin', rule: 0 },
                    { title: 'Admin', rule: 1},
                    { title: 'Manager', rule: 2 },
                    { title: 'User', rule: 3 },                 
                  ],
      inputRules: [
         v => v.length >= 5 || 'Minimum length is 5 characters !'
      ],
      UserAccount: {
        username: '',
        password: '',
        role: 0,
        company: '',
        gender: 0,
        status: 0
      }
    }),
   methods: {
     saveData() { 
         this.axios.post('http://localhost:50598/api/userAccount', this.UserAccount).then((response) => {             
           if (response.data.isRejected = true) {
             console.log(response.data.data)               
           }
           else {
             console.log(response.data.data);
           }
         })                     
     },
   }
}
</script>
