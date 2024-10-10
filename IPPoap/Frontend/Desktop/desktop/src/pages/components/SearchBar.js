import React from "react";
import "./SearchBar.css";
import SearchIcon from "@mui/icons-material/Search";


function SearchBar({ placeholder /*, data*/ }) {
  return (
    <div className="search">
      <div className="searchInputs">
        <div className="searchIcon">
          <SearchIcon />
        </div>
        <input type="text" placeholder={placeholder} />
      </div>
      <div className="dataResult"> </div>
    </div>
  );
}

export default SearchBar;
