<template>
<div id="app">
 <v-app id="inspire">
    <v-card>
      <v-card-title>
        List Branch
        <v-spacer></v-spacer>
        <v-text-field v-model="search" append-icon="mdi-magnify" label="Search" single-line hide-details></v-text-field>
      </v-card-title>
      <v-data-table fixed-header height="450" :headers="headers" :items="branobjs" :search="search" dense>
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
      branobjs:[],
      search: '',
      dialogDelete: false,
      headers: [
        { text: 'Name', align: 'start', sortable: false, value: 'name',},
        { text: 'Address', value: 'address' },
        { text: 'Location', value: 'location'},              
        { text: 'Actions', value: 'actions', sortable: false },
      ],
    }
  },
      watch: {    
        dialogDelete (val) {
          val || this.closeDelete()
        },        
      },
      mounted(){  
        localStorage.setItem('branid', JSON.stringify(0));       
        const _this = this;        
        axios.get('/api/branch/GetBranch').then(response => { 
          console.log(response.data)
          _this.branobjs = response.data;
      })
      },
      methods: {
        editItem (item) {
          // console.log(item);
          // var usid = { '_uerid': item,};
          // Put the object into storage
          localStorage.setItem('branid', JSON.stringify(item));
          this.$router.push('branch-form');
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
