import React from 'react'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
const Router = () => {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginForm />} />
      </Routes>
    </Router>
  )
}

export default Router