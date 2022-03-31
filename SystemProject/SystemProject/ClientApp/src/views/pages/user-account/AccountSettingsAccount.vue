<template>
  <v-container>
      <v-card flat class="pa-3 mt-2">
    <v-card-text>
      <v-form class="multi-col-validation mt-6" ref="form">
        <v-row>
          <v-col md="6" cols="12">
            <v-text-field label="Username" dense outlined v-model="UserAccount.username" :rules="usernameRule"></v-text-field>
          </v-col>
          <v-col md="6" cols="12">
            <v-text-field label="Password" dense outlined type="Password" v-model="UserAccount.password" :rules="passwordRule"></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <v-select dense outlined label="Rule" :items="user_rules" v-model="UserAccount.rule" item-text="title" item-value="rule" :rules="ruleRule"></v-select>
          </v-col>
          <v-col cols="12" md="6">
            <v-text-field dense outlined label="Company" v-model="UserAccount.company" :rules="companyRule"></v-text-field>
          </v-col>
          <v-col cols="12" md="6">
            <p class="text--primary mt-n3 mb-2">
              Gender
            </p>
            <v-radio-group row class="mt-0" hide-details v-model="UserAccount.gender" :rules="genderRule">
              <v-radio value:1 label="Male"></v-radio>
              <v-radio value:2 label="Female"></v-radio>
              <v-radio value:3 label="Other"></v-radio>
            </v-radio-group>
          </v-col>
          <v-col cols="12" md="6">
            <v-select dense outlined label="Status" :items="statuss" v-model="UserAccount.status" item-text="title" item-value="status" :rules="statusRule"></v-select>
          </v-col>
          <!-- tbn save -->
          <v-col cols="12">
            <v-btn small color="primary" class="me-3 mt-4" @click.prevent="saveData"> Save   </v-btn>
            <v-btn small color="secondary" outlined class="mt-4" @click.prevent="onClickTop">  Cancel </v-btn>            
          </v-col>
        </v-row>
      </v-form>
    </v-card-text>
  </v-card> 
  <div class="text-center">
    <notificationGroup group="top">
            <div class="fixed inset-0 top-12 z-50 flex px-4 py-6 pointer-events-none p-6 items-start justify-end">
              <div class="max-w-sm">
                <notification v-slot="{notifications}">
                  <div class="flex max-w-sm w-full mx-auto bg-white shadow-md rounded-lg overflow-hidden mt-4"
                      v-for="notification in notifications"
                      :key="notification.id">
                    <div class="flex justify-center items-center w-12 bg-green-500">
                      <svg
                        class="h-6 w-6 fill-current text-white"
                        viewBox="0 0 40 40"
                        xmlns="http://www.w3.org/2000/svg">
                        <path
                          d="M20 3.33331C10.8 3.33331 3.33337 10.8 3.33337 20C3.33337 29.2 10.8 36.6666 20 36.6666C29.2 36.6666 36.6667 29.2 36.6667 20C36.6667 10.8 29.2 3.33331 20 3.33331ZM16.6667 28.3333L8.33337 20L10.6834 17.65L16.6667 23.6166L29.3167 10.9666L31.6667 13.3333L16.6667 28.3333Z"
                        ></path>
                      </svg>
                    </div>
                    <div class="-mx-3 py-2 px-4">
                      <div class="mx-3">
                        <span class="text-green-500 font-semibold">{{notification.title}}</span>
                        <p class="text-gray-600 text-sm">{{notification.text}}</p>
                      </div>
                    </div>
                  </div>
                </notification>
              </div>
            </div>
      </notificationGroup>
      <notificationGroup group="bottom" position="bottom">
          <div class="fixed inset-x-3 bottom-6 flex px-2 py-4 p-4 items-start justify-end">
            <div class="max-w-sm max-h-96">
              <notification v-slot="{notifications}">
                <div class="flex max-w-sm w-full mx-auto bg-white shadow-md rounded-lg overflow-hidden mt-2"
                     v-for="notification in notifications"
                     :key="notification.id">
                  <div class="flex max-w-sm justify-center items-center w-12 bg-red-500">
                    <svg class="h-6 w-6 fill-current text-white"
                         viewBox="0 0 40 40"
                         xmlns="http://www.w3.org/2000/svg">
                      <path d="M20 3.36667C10.8167 3.36667 3.3667 10.8167 3.3667 20C3.3667 29.1833 10.8167 36.6333 20 36.6333C29.1834 36.6333 36.6334 29.1833 36.6334 20C36.6334 10.8167 29.1834 3.36667 20 3.36667ZM19.1334 33.3333V22.9H13.3334L21.6667 6.66667V17.1H27.25L19.1334 33.3333Z"></path>
                    </svg>
                  </div>
                  <div class="-mx-3 py-2 px-4">
                    <div class="mx-3">
                      <span class="text-red-500 font-semibold">{{notification.title}}</span>
                      <p class="text-gray-600 text-sm">{{notification.text}}</p>
                    </div>
                  </div>
                </div>
              </notification>
            </div>
          </div>
        </notificationGroup>
  </div>
  </v-container>  
</template>

<script>
import axios from 'axios'
export default {
  data: () => ({
      statuss: [
                { title: 'Active', status: 1 },
                { title: 'Inactive', status: 2 },
                { title: 'Pending', status: 3 },
                { title: 'Close', status: 4 },                 
            ],
      user_rules: [
                    { title: 'Super Admin', rule: 1 },
                    { title: 'Admin', rule: 2},
                    { title: 'Manager', rule: 3 },
                    { title: 'User', rule: 4 },                 
                  ],
        usernameRule: [v => v.length > 5 || 'Username is required 5 charater !'],
        passwordRule: [v => v.length > 5 || 'Password is required 5 charater !'],
        ruleRule: [v => !!v || 'Rule is required !'],
        companyRule: [v => !!v || 'Company is required !'],
        genderRule: [v => !!v || 'Gender is required !'],
        statusRule: [v => !!v || 'Status is required !'],
      UserAccount: {
        username: '',
        password: '',
        rule: 0,
        company: '',
        gender: 0,
        status: 0
      }
    }),
    methods: {
      onClickTop() {
        this.$notify(
          {
            group: "top",
            title: "Success",
            text: "Your account !"
          },
          5000
        );
      },
      saveData() {
        if (this.$refs.form.validate()){
          console.log();
        }
        let _this = this;
        this.axios.post('http://localhost:50598/api/userAccount', this.UserAccount).then((response) => {
          let message = response.data.data;
          //_this.inputRules = [v => v.length >= 5 || 'Minimum length is 5 characters !'];
           if (response.data.isRejected = true) {
             console.log(response.data.data)
             var keys = Object.getOwnPropertyNames(message);
             for (let i = 0; i < keys.length; i++) {
               //_this.inputRules = [v => v.length >= 5 || message[keys[i]]];
               _this.$notify(
                 {
                   group: "bottom",
                   title: "Error",
                   text: message[keys[i]]
                 },
                 7000
               );
             }
            
           }
           else {                
             //onClickTop();
             _this.$notify(
               {
                 group: "top",
                 title: "Success",
                 text: "Your account !"
               },
               5000
             );
             console.log(response.data.data);
           }
         })                     
     },
   }
}
</script>
