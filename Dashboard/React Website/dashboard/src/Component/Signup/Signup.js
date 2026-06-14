import React from 'react'
import { Helmet } from "react-helmet";
import { Link } from "react-router-dom";
import logo from "./assets/img/logo-fb.png"; // Importing image properly
const Signup = () => {
  return (
    <>
      {/* Helmet for head section */}
      <Helmet>
        <title>Account Login</title>
        <link rel="icon" type="image/png" href="/assets/img/favicon.png" />
        <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
        <link rel="stylesheet" href="/assets/css/all.min.css" />
        <link rel="stylesheet" href="/assets/css/uf-style.css" />

        {/* JavaScript Files */}
        <script src="/assets/js/popper.min.js" defer></script>
        <script src="/assets/js/bootstrap.min.js" defer></script>
      </Helmet>

      {/* Login Form */}
      <div className="uf-form-signin">
        <div className="text-center">
          <a href="https://uifresh.net/">
            <img src={logo} alt="Logo" width="100" height="100" />
          </a>
          <h1 className="text-white h3">Account Login</h1>
        </div>

        <form className="mt-4">
          <div className="input-group uf-input-group input-group-lg mb-3">
            <span className="input-group-text fa fa-user"></span>
            <input type="text" className="form-control" placeholder="Username or Email address" />
          </div>

          <div className="input-group uf-input-group input-group-lg mb-3">
            <span className="input-group-text fa fa-lock"></span>
            <input type="password" className="form-control" placeholder="Password" />
          </div>

          <div className="d-flex mb-3 justify-content-between">
            <div className="form-check">
              <input type="checkbox" className="form-check-input uf-form-check-input" id="exampleCheck1" />
              <label className="form-check-label text-white" htmlFor="exampleCheck1">
                Remember Me
              </label>
            </div>
            <Link to="#">Forgot password?</Link>
          </div>

          <div className="d-grid mb-4">
            <button type="submit" className="btn uf-btn-primary btn-lg">
              Login
            </button>
          </div>

          <div className="d-flex mb-3">
            <div className="dropdown-divider m-auto w-25"></div>
            <small className="text-nowrap text-white">Or login with</small>
            <div className="dropdown-divider m-auto w-25"></div>
          </div>

          <div className="uf-social-login d-flex justify-content-center">
            <Link to="#" className="uf-social-ic" title="Login with Facebook">
              <i className="fab fa-facebook-f"></i>
            </Link>
            <Link to="#" className="uf-social-ic" title="Login with Twitter">
              <i className="fab fa-twitter"></i>
            </Link>
            <Link to="#" className="uf-social-ic" title="Login with Google">
              <i className="fab fa-google"></i>
            </Link>
          </div>

          <div className="mt-4 text-center">
            <span className="text-white">Don't have an account?</span>
            <Link to="/register">Sign Up</Link>
          </div>
        </form>
      </div>
    </>
  );
};


export default Signup