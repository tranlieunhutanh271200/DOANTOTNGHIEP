import { useCallback, useEffect, useRef, useState } from "react";
import { Link } from "react-router-dom";
import PaginationComponent from "../pagination/pagination.component";
import "./datatable.css";
const paginationDefault = {
  currentPage: 1,
  pageSize: 5,
  totalPages: 15,
};
const DataTableComponent = ({
  headerTitle,
  headers = [],
  rows = [],
  pagination = paginationDefault,
  idColumn,
  imageColumns = [],
  columnsTemplate = [],
  customizeColumns = [],
  hideColumns = [],
  isAddable = false,
  isEditable = false,
  editUrl = "#",
  isDeleteable = false,
  isImportable = false,
  openAddModal,
  openEditModal,
  openDeleteModal,
  openImportModal,
  currentSelected = null,
  fetch = false,
}) => {
  const [masterData, setMasterData] = useState(rows);
  const [isFetch, setIsFetch] = useState(fetch);
  const [currentItems, setCurrentItems] = useState([]);
  const memory = useRef(rows);
  memory.current = masterData;
  const [paging, setPaging] = useState({
    ...pagination,
  });
  // useEffect(() => {
  //   setPaging({
  //     ...pagination,
  //     totalPages: Math.ceil(rows.length / 5),
  //   });
  // }, [rows]);
  useEffect(() => {
    setMasterData([...rows]);
  }, [rows]);

  const pageChange = (x) => {
    setPaging({ ...paging, currentPage: x });
    setCurrentItems([
      ...rows.slice(
        (x - 1) * paging.pageSize,
        (x - 1) * paging.pageSize + paging.pageSize
      ),
    ]);
    setIsFetch(true);
  };
  const [searchValue, setSearchValue] = useState("");
  useEffect(() => {
    pageChange(1);
    console.log(currentItems);
  }, [masterData]);
  useEffect(() => {
    if (searchValue !== "") {
      // console.log(memory.current?.filter(x => Object.keys(x).some((key,idx) => {
      //   console.log(x[key].toLowerCase().includes(searchValue.toLowerCase()));
      //   if(x[key].toLowerCase().includes(searchValue.toLowerCase())){
      //     return true;
      //   }
      //   else{
      //     return false;
      //   }
      // })));
      setCurrentItems(
        memory.current?.filter((x) =>
          Object.keys(x).some((key, idx) => {
            console.log(
              x[key].toLowerCase().includes(searchValue.toLowerCase())
            );
            if (x[key].toLowerCase().includes(searchValue.toLowerCase())) {
              return true;
            } else {
              return false;
            }
          })
        )
      );
    } else {
      setCurrentItems([...rows]);
    }
  }, [searchValue]);
  return (
    <div className="datatable">
      <div className="header">
        <h3>{headerTitle}</h3>
        <div className="form-group w-25">
          <input
            onChange={(e) => setSearchValue(e.target.value)}
            type="text"
            className="form-field"
            placeholder="Tìm kiếm"
          />
        </div>
        <div className="d-flex">
          {isAddable && (
            <button onClick={openAddModal} className="noselect primary">
              <span className="text">Thêm</span>
              <span className="icon">
                <ion-icon name="add-outline" size="large"></ion-icon>
              </span>
            </button>
          )}
          {isImportable && (
            <button onClick={openImportModal} className="btn btn-secondary">
              Import{" "}
              <ion-icon size="large" name="add-circle-outline"></ion-icon>
            </button>
          )}
        </div>
      </div>
      <div className="body">
        <table className="table-glassmorphism">
          <thead>
            <tr>
              {headers.length === 0
                ? Object.keys(rows[0]).map((header) => {
                    if (!hideColumns.includes(header)) {
                      return (
                        <th key={header}>
                          {header[0].toUpperCase() +
                            header.substring(1, header.length)}
                        </th>
                      );
                    }
                  })
                : headers.map((header, idx) => <th key={idx}>{header}</th>)}
              {customizeColumns.length > 0 &&
                customizeColumns.map((col, idx) => <th key={idx}>{col.header}</th>)}
              <th>Chức năng</th>
            </tr>
          </thead>
          <tbody>
            {currentItems.map((row, idx) => (
              <tr
                key={idx}
                className={`${currentSelected === row ? "bg-primary" : ""}`}
              >
                {Object.keys(row).map((col) => {
                  if (!hideColumns.includes(col)) {
                    return (
                      <td
                        className={`${
                          imageColumns.includes(col) ? "image-box" : ""
                        }`}
                        key={`${col}-${idx}`}
                      >
                        {columnsTemplate.findIndex((x) => x.key === col) !==
                        -1 ? (
                          columnsTemplate
                            .find((x) => x.key === col)
                            .template(row[col])
                        ) : imageColumns.includes(col) ? (
                          <img src={row[col]} alt={col} />
                        ) : (
                          row[col]
                        )}
                      </td>
                    );
                  }
                })}
                {customizeColumns.length > 0 &&
                  customizeColumns.map((col, idx) => (
                    <td key={idx}>{col.body(row)}</td>
                  ))}
                <td>
                  <div className="align-center">
                    {isEditable && (
                      <button
                        onClick={() => {
                          if (editUrl === "#") {
                            openEditModal(row);
                          }
                        }}
                        className="noselect warning"
                      >
                        <span className="text">Sửa</span>
                        <span className="icon">
                          <ion-icon
                            size="large"
                            name="create-outline"
                          ></ion-icon>
                        </span>
                      </button>
                    )}
                    {isDeleteable && (
                      <button
                        onClick={() => openDeleteModal(row)}
                        className="noselect danger"
                      >
                        <span className="text">Xóa</span>
                        <span className="icon">
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                          >
                            <path d="M24 20.188l-8.315-8.209 8.2-8.282-3.697-3.697-8.212 8.318-8.31-8.203-3.666 3.666 8.321 8.24-8.206 8.313 3.666 3.666 8.237-8.318 8.285 8.203z"></path>
                          </svg>
                        </span>
                      </button>
                    )}
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {isFetch && (
        <div className="footer">
          <PaginationComponent
            currentPage={paging.currentPage}
            totalPage={Math.ceil(masterData.length / 5)}
            pageChange={(x) => pageChange(x)}
          ></PaginationComponent>
        </div>
      )}
    </div>
  );
};

export default DataTableComponent;
