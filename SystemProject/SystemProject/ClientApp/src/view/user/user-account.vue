<template>
		<form class="bg-white p-5 rounded-lg shadow-lg min-w-full">
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="username">Username</label>
				  <input class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border rounded-lg focus:outline-none" type="text" placeholder="Small input"/>
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">Email</label>
					<input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="text" name="email" id="email" placeholder="@email" />
        </div>
      </div>

			<div>
				<label class="text-gray-800 font-semibold block my-3 text-md" for="username">Username</label>
				<input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="text" name="email" id="email" placeholder="@email" />
      </div>
				<div>
					<label class="text-gray-800 font-semibold block my-3 text-md" for="email">Email</label>
					<input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="text" name="email" id="email" placeholder="@email" />
      </div>

			<div>
						<label class="text-gray-800 font-semibold block my-3 text-md" for="password">Password</label>
						<input class="w-full bg-gray-100 px-4 py-2 rounded-lg focus:outline-none" type="text" name="password" id="password" placeholder="password" />
      </div>
						<div>
							<label class="text-gray-800 font-semibold block my-3 text-md" for="confirm">Confirm password</label>
							<input class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border rounded-lg focus:shadow-outline" type="text" placeholder="Small input"/>
      </div>
							<button type="submit" class="w-full mt-6 bg-indigo-600 rounded-lg px-4 py-2 text-lg text-white tracking-wide font-semibold font-sans">Register</button>
							<button type="submit" class="w-full mt-6 mb-3 bg-indigo-100 rounded-lg px-4 py-2 text-lg text-gray-800 tracking-wide font-semibold font-sans">Login</button>
		</form>
</template>
<script>
export default {
  name: 'export-excel',
  data () {
    return {

    }
  },
}
</script>
