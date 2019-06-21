import HomePage from 'components/home-page'
import AuthorizationPage from 'components/authorize/authorization-page'
import CreatePost from 'components/post/create-post'
import UserManagement from 'components/authorize/user-management-page'
import Chat from 'components/chat/chat-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'login', path: '/login', component: AuthorizationPage, props: { isLogin: true } },
  { name: 'signup', path: '/signup', component: AuthorizationPage, props: { isLogin: false } },
  { name: 'create-post', path: '/create-post', component: CreatePost },
  { name: 'user-management', path: '/user-management', component: UserManagement },
  { name: 'chat', path: '/chat/:id', component: Chat }
]
