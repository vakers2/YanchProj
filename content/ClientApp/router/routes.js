import HomePage from 'components/home-page'
import AuthorizationPage from 'components/authorize/authorization-page'
import CreatePost from 'components/post/create-post'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'login', path: '/login', component: AuthorizationPage, props: { isLogin: true } },
  { name: 'signup', path: '/signup', component: AuthorizationPage, props: { isLogin: false } },
  { name: 'create-post', path: '/create-post', component: CreatePost }
]
