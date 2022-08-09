import { getParams } from '@/libs/util'
const USER_MAP = {
  super_admin: {
    name: 'super_admin',
    user_id: '1',
    access: ['AGC01', 'AGB01','AGU01'],
    token: 'super_admin',
    avatar: 'https://file.iviewui.com/dist/a0e88e83800f138b94d2414621bd9704.png'
  },
  admin: {
    name: 'admin',
    user_id: '2',
    access: ['AGC01','AGB01','AGU01'],
    token: 'admin',
    avatar: 'https://avatars0.githubusercontent.com/u/20942571?s=460&v=4'
  }
}

export const login = req => {
  req = JSON.parse(req.body)
  return { token: USER_MAP[req.userName].token }
}

export const getUserInfo = req => {  
  const params = getParams(req.url)  
  const access = localStorage.getItem('access');  
  const userAcc = {
        name: localStorage.getItem('name'),
        user_id: localStorage.getItem('user_id'),
        access: access.split(','),
        token: localStorage.getItem('token'),
        avatar: localStorage.getItem('avatar')
  };
  console.log(USER_MAP);
  console.log("UserAcc", userAcc);
  // return USER_MAP[params.token]
  // console.log("Usermap",USER_MAP);
  // console.log("access", userAcc);
  return userAcc
}

export const logout = req => {
  return null
}
