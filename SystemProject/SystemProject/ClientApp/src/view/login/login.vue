
<style lang="less">
  @import './login.less';
</style>
<template>
  <div class="login">
    <form class="justify-center mt-56 mr-60 items-center w-full shadow rounded-lg bg-white px-4 flex flex-col md:w-1/5 lg:w-1/5 m-auto" @keyup.enter="signin">
    <h2 class="text-2xl my-4">Login</h2>
			<div class="w-full p-2 justify-start flex flex-col">
        <div class="flex flex-ror">
          <label class="block text-blueGray-600 text-xs font-bold mb-2" for="grid-password">{{$t('Username')}} :</label>
        </div>
				<div class=" flex flex-row">          
					<span class="z-highest rounded-l-lg w-10 h-8 flex justify-center items-center text-2xl text-gray-400 border-solid border border-gray-400 border-r-0" mode="render" block="">
						<svg aria-hidden="true" role="img" width="1em" height="1em" preserveAspectRatio="xMidYMid meet" viewBox="0 0 26 26" class="iconify iconify--wpf">
							<path d="M16.563 15.9c-.159-.052-1.164-.505-.536-2.414h-.009c1.637-1.686 2.888-4.399 2.888-7.07c0-4.107-2.731-6.26-5.905-6.26c-3.176 0-5.892 2.152-5.892 6.26c0 2.682 1.244 5.406 2.891 7.088c.642 1.684-.506 2.309-.746 2.397c-3.324 1.202-7.224 3.393-7.224 5.556v.811c0 2.947 5.714 3.617 11.002 3.617c5.296 0 10.938-.67 10.938-3.617v-.811c0-2.228-3.919-4.402-7.407-5.557z" fill="currentColor">
							</path>
						</svg>
					</span>
					<input v-model="userSignin.userName" class="border-solid border border-gray-400 rounded-r-lg outline-none focus:ring-1 ring-blue-400 w-full pl-1" required="false" :placeholder="$t('Username')" />
				</div>
				<div class="mt-4 flex flex-ror">
          <label class="block text-blueGray-600 text-xs font-bold mb-2" for="grid-password">{{$t('Password')}} :</label>
        </div>
				<div class="flex flex-row">
					<span class="z-highest rounded-l-lg w-10 h-8 flex justify-center items-center text-2xl text-gray-400 border-solid border border-gray-400 border-r-0" mode="render" block="">
						<svg aria-hidden="true" role="img" width="1em" height="1em" preserveAspectRatio="xMidYMid meet" viewBox="0 0 32 32" class="iconify iconify--carbon">
							<path d="M21 2a8.998 8.998 0 0 0-8.612 11.612L2 24v6h6l10.388-10.388A9 9 0 1 0 21 2zm0 16a7.013 7.013 0 0 1-2.032-.302l-1.147-.348l-.847.847l-3.181 3.181L12.414 20L11 21.414l1.379 1.379l-1.586 1.586L9.414 23L8 24.414l1.379 1.379L7.172 28H4v-3.172l9.802-9.802l.848-.847l-.348-1.147A7 7 0 1 1 21 18z" fill="currentColor">
							</path>
							<circle cx="22" cy="10" r="2" fill="currentColor">
							</circle>
						</svg>
					</span>
					<input v-model="userSignin.password" type="password" class="border-solid border border-gray-400 h-8 rounded-r-lg outline-none focus:ring-1 ring-blue-400 w-full pl-1" :placeholder="$t('Password')" required="false">
				</div>
				<button type="button" @click="signin" class="px-4 py-2 rounded bg-blue-700 text-white hover:bg-blue-500 my-4 w-full">Login</button>
			</div>
		</form>
  </div>
</template>
<script>
import axios from 'axios' 
import { mapActions } from 'vuex'
  export default {
    data: () => ({
      userSignin: {
        userName:'super_admin',
        password:''
      }
    }),
    methods: {
      ...mapActions([
        'handleLogin',
        'getUserInfo'
      ]),
      // handleSubmit({ userName, password }) {
      //   this.handleLogin({ userName, password }).then(res => {
      //     this.getUserInfo().then(res => {
      //       this.$router.push({
      //         name: this.$config.homeName
      //       })
      //     })
      //   })
      // },
      signin(){    
        let userName = 'super_admin';
        let password = '1234'    
        this.handleLogin({ userName, password }).then(res => {
          this.getUserInfo().then(res => {
            this.$router.push({
              name: this.$config.homeName
            })
          })
        })
        // let _this = this;   
        // console.log(this.userSignin)      
        axios.post('/api/userAccount/SignIn', this.userSignin).then((response) => {
          if (response.data.isRejected == true) {

          }
          else{            
          }
        })      
        
      }
    } 
  }   
</script>

