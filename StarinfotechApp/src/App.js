import logo from './logo.svg';
import './App.css';
import { NavLink, Route, Routes } from 'react-router-dom';

import Home from '../src/Home/Home';
import About from '../src/About/About';
import Course from '../src/Course/Course';
import Contact from '../src/Contact/Contact';
import Login from '../src/Login/Login';
import Register from '../src/Register/Register';
import UserList from '../src/User/UserList';
import UserView from '../src/User/UserView';
import UserEdit from '../src/User/UserEdit';

const App = () => {
  return (
    <div>

      <header>
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
          <div className="container-fluid">
            <a className="navbar-brand" href="/">STAR INFOTECH</a>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarNavDropdown">
              <ul className="navbar-nav me-auto">
                <li className="nav-item">
                  <NavLink className="nav-link" to="/">Home</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/about">About</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/course">Courses</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/contact">Contact</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/user-list">Users</NavLink>
                </li>
              </ul>
              <ul className="navbar-nav ms-auto">
                <li className="nav-item">
                  <NavLink className="nav-link" to="/login">Login</NavLink>
                </li>
                <li className="nav-item">
                  <NavLink className="nav-link" to="/register">Register</NavLink>
                </li>
                <li className="nav-item">
                  <span className="nav-link">Hello</span>
                </li>
                <li className="nav-item">
                  <a className="nav-link" asp-controller="Login" asp-action="Logout">Logout</a>
                </li>
              </ul>
            </div>
          </div>
        </nav>
      </header>
      <main>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/about' element={<About />} />
          <Route path='/course' element={<Course />} />
          <Route path='/contact' element={<Contact />} />
          <Route path='/login' element={<Login />} />
          <Route path='/register' element={<Register />} />
          <Route path='/user-list' element={<UserList />} />
          <Route path='/user-view' element={<UserView />} />
          <Route path='/user-edit' element={<UserEdit />} />
        </Routes>
      </main>
      <footer>
        <hr />
        Footer
      </footer>
    </div>
  );
}

export default App;
