<template>
<div id="app">
 <v-app id="inspire">
   <div class="pb-1" role="alert">
      <div class="bg-gray-400 text-white font-bold rounded-t px-4 py-0.5 w-full flex">
        <div class="w-full md:w-2/2 flex">
          {{$t('User Account')}}
        </div>
         <div class="w-full md:w-2/2 flex">           
          <input v-model="search" class="placeholder:italic text-gray-600 font-normal bg-white w-full border border-slate-300 rounded-md pt-0.5 pl-9 pr-3 shadow-sm focus:outline-none focus:border-sky-500 focus:ring-sky-500 focus:ring-1 sm:text-sm" placeholder="Search..." type="text" name="search"/>
        </div>
      </div>            
    </div>
    <v-card>
      <!-- <v-card-title>
        List User Acccount
        <v-spacer></v-spacer>
        <v-text-field v-model="search" append-icon="mdi-magnify" label="Search" single-line hide-details></v-text-field>
      </v-card-title> -->
      <v-data-table fixed-header height="450" :headers="headers" :items="userobjs" :search="search" dense>
         <template>
            <v-toolbar  flat>
              <v-dialog v-model="dialogDelete">
                <v-card>
                  <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
                    <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:item.actions="{ item }">
            <v-icon small class="mr-2" color="indigo" @click="editItem(item.id)">
              mdi-pencil
            </v-icon>
            <v-icon small color="red lighten-2" @click="deleteItem(item)">
              mdi-delete
            </v-icon>
          </template>
      </v-data-table>
    </v-card>
  </v-app>
</div>
</template>
<script>
    import axios from 'axios' 
    export default {
   data () {
    return {      
      userobjs:[],
      search: '',
      dialogDelete: false,
      headers: [
        { text: this.$t('UserName'),persistent:true, align: 'start',sortable: false, value: 'userName',},
        { text: this.$t('Gender'), value: 'gender' },
        { text: this.$t('Branch'), value: 'branch'},
        { text: this.$t('Role'), value: 'rule'},
        { text: this.$t('Status'), value: 'status' },       
        { text: this.$t('Actions'), value: 'actions', sortable: false },
      ],
    }
  },
      watch: {    
        dialogDelete (val) {
          val || this.closeDelete()
        },        
      },
      mounted(){        
        const _this = this;
        axios
        .get('/api/userAccount/getUserAccount').then(response => {         
          _this.userobjs = response.data;          
      })
      },
      methods: {
        editItem (item) {
          // console.log(item);
          // var usid = { '_uerid': item,};
          // Put the object into storage
          localStorage.setItem('usid', item);
          this.$router.push('useraccount-form');
        },
        // deleteItem (item) {         
        //   this.editedIndex = this.desserts.indexOf(item)
        //   this.editedItem = Object.assign({}, item)
        //   this.dialogDelete = true
        // },
        // deleteItemConfirm () {
        //   this.desserts.splice(this.editedIndex, 1)
        //   this.closeDelete()
        // },
      }    
 }  
</script>
<style>
.v-data-table--dense > .v-data-table__wrapper > table > tbody > tr > td {
    height: 25px !important;
    font-size: inherit !important;
}
.v-card__subtitle, .v-card__text, .v-card__title {
    padding: 5px !important;
}
.v-card__title {
  font-size: 1.1rem !important;
  align-items: unset !important;
}
.v-text-field {
    padding-top: 0 !important; 
    margin-top: 0 !important;
}
.theme--light.v-data-table > .v-data-table__wrapper > table > thead > tr:last-child > th {
  border: 0.5px solid gray !important;
}
.v-data-table--dense > .v-data-table__wrapper > table > tbody > tr > td{
  border: 0.5px solid gray !important;
}
</style>
