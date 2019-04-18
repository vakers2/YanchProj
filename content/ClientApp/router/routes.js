import HomePage from 'components/home-page'
import AuthorizationPage from 'components/authorization-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'login', path: '/login', component: AuthorizationPage }
]
