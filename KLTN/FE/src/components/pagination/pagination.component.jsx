import { useCallback, useEffect, useRef, useState } from "react";
import "./pagination.css";
const PaginationComponent = ({
  totalPage = 10,
  currentPage = 1,
  isLoading = false,
  pageChange,
}) => {
  const pagesRef = useRef();
  const [current, setCurrent] = useState(currentPage);
  const [pages, setPages] = useState(
    [...Array(totalPage).keys()].map((val) => {
      var page = {
        page: val + 1,
        hide: false,
      };
      return page;
    })
  );
  useEffect(() => {
    setPages(
      [...Array(totalPage).keys()].map((val) => {
        var page = {
          page: val + 1,
          hide: false,
        };
        return page;
      })
    );
  }, [totalPage]);
  const [showPages, setShowPages] = useState([
    ...pages.slice(current - 1, current + 4),
  ]);
  useEffect(() => {
    setShowPages([...pages.slice(current - 1, current + 4)]);
  }, [pages]);
  useEffect(() => {
    pagesRef.current.childNodes.forEach((child, idx) => {
      child.addEventListener("click", () => {
        pagesRef.current.childNodes.forEach((temp) => {
          temp.classList.remove("current");
        });
        child.classList.add("current");
        setCurrent(parseInt(child.innerText));
      });
    });
  }, []);
  const move = (isPrev) => {
    const x = isPrev
      ? current > 1
        ? current - 1
        : totalPage
      : current < totalPage
      ? current + 1
      : 1;

    setCurrent(x);
    let data = [];
    if (x === showPages[showPages.length - 1].page || x === showPages[0].page) {
      if (isPrev) {
        data = pages.slice(current - 4, current);
      } else {
        data = pages.slice(current - 1, current + 4);
      }
      setShowPages(data);
    }
  };
  return (
    <div className="pagination_page">
      <div className="indicator">
        <ion-icon
          onClick={() => move(true)}
          name="chevron-back-outline"
        ></ion-icon>
      </div>
      <div className="pagination" ref={pagesRef}>
        {showPages.map((val) => (
          <button
            onClick={() => {
              setCurrent(val.page);
              pageChange(val.page);
            }}
            disabled={isLoading || val.hide}
            className={`page ${val.page === current ? "current" : ""}`}
            key={val.page}
          >
            {!val.hide ? val.page : "..."}
          </button>
        ))}
      </div>
      <div className="indicator">
        <ion-icon
          onClick={() => move(false)}
          name="chevron-forward-outline"
        ></ion-icon>
      </div>
    </div>
  );
};

export default PaginationComponent;
