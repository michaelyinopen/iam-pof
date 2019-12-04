import React from 'react';
import { Route, Switch } from 'react-router';
import PrivateRoute from "./components/PrivateRoute";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import FetchData from './components/FetchData';
import { Counter } from './components/Counter';
import { useAuth0 } from "./react-auth0-spa";
import Profile from "./components/Profile";

const App = () => {
  const { loading } = useAuth0();

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <Layout>
      <Switch>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <PrivateRoute path='/fetch-data' component={FetchData} />
        <PrivateRoute path="/profile" component={Profile} />
      </Switch>
    </Layout>
  );
};

export default App;
