import React from "react";
import { useAuth0 } from "../react-auth0-spa";
import { Link } from "react-router-dom";
import { NavItem, NavLink } from 'reactstrap';

const AuthNavItems = () => {
  const { isAuthenticated, loginWithRedirect, logout } = useAuth0();

  return (
    <React.Fragment>
      {!isAuthenticated && (
        <NavItem>
          <NavLink tag="button" className="text-dark" onClick={() => loginWithRedirect({})}>Log in</NavLink>
        </NavItem>
      )}

      {isAuthenticated && (
        <NavItem>
          <NavLink tag="button" className="text-dark" onClick={() => logout()}>Log out</NavLink>
        </NavItem>
      )}

      {isAuthenticated && (
        <NavItem>
          <NavLink tag={Link} className="text-dark" to="/profile">Profile</NavLink>
        </NavItem>
      )}
    </React.Fragment>
  );
};

export default AuthNavItems;