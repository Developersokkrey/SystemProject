<template>
  <v-card
    flat
    class="pa-3 mt-2"
  >
    <v-card-text>
      <v-form class="multi-col-validation mt-6">
        <v-row>
          <v-col
            md="6"
            cols="12"
          >
            <v-text-field              
              label="Username"
              dense
              outlined
              v-model="UserAccount.username"
            ></v-text-field>
          </v-col>

          <v-col
            md="6"
            cols="12"
          >
            <v-text-field              
              label="Password"
              dense
              outlined
              type="Password"
              v-model="UserAccount.password"
            ></v-text-field>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-select              
              dense
              outlined
              label="Role"
              :items="roles"
              v-model="UserAccount.role"
              item-text="title"
              item-value="role"
            ></v-select>
          </v-col>

          <v-col
            cols="12"
            md="6"
          >
            <v-text-field              
              dense
              outlined
              label="Company"
              v-model="UserAccount.company"
            ></v-text-field>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <p class="text--primary mt-n3 mb-2">
              Gender
            </p>
            <v-radio-group              
              row
              class="mt-0"
              hide-details
              v-model="UserAccount.gender"
            >
              <v-radio
                value:0
                label="Male"
              >
              </v-radio>
              <v-radio
                value:1
                label="Female"
              >
              </v-radio>
              <v-radio
                value:2
                label="Other"
              >
              </v-radio>
            </v-radio-group>
          </v-col>
          <v-col
            cols="12"
            md="6"
          >
            <v-select              
              dense
              outlined
              label="Status"
              :items="statuss"
              v-model="UserAccount.status"
              item-text="title"
              item-value="status"
            >              
            </v-select>
          </v-col>
          <!-- tbn save -->
          <v-col cols="12">
            <v-btn
              color="primary"
              class="me-3 mt-4"
              @click.prevent="saveData"
            >
              Save changes
            </v-btn>
            <v-btn
              color="secondary"
              outlined
              class="mt-4"
              type="reset"
              @click.prevent="resetForm"
            >
              Cancel
            </v-btn>
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
      roles: [
                { title: 'Super Admin', role: 0 },
                { title: 'Admin', role: 1},
                { title: 'Manager', role: 2 },
                { title: 'User', role: 3 },                 
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
     saveData(){
       this.axios.post('http://localhost:50598/api/userAccount', this.UserAccount).then((response) =>{
          console.log(response.data)
       })
       //this.axios.post('https://jsonplaceholder.typicode.com/posts', this.UserAccount).then((response) => {
       //   console.log(response.data)
       //})
     }
   }
}
</script>
