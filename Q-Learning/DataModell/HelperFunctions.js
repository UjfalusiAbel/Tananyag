const margin = {top: 10, right: 30, bottom: 30, left: 60};
const diff = 30;

const getSvg = (id, width, height) =>{
    width = width - margin.left - margin.right;
    height = height - margin.top - margin.bottom;
    return d3.select(id)
             .append("svg")
             .attr("width", width + margin.left + margin.right + diff)
             .attr("height", height + margin.top + margin.bottom + diff)
             .append("g")
             .attr("transform", "translate(" + margin.left + "," + margin.top + ")");
}

const prepareSvg = (id, width, height, data) => {
    const svg = getSvg(id, width, height);
    const x = d3.scaleLinear().domain(d3.extent(data, (d) => {return d.Item1;})).range([0,width]);
    svg.append("g").attr("transform","translate(0," + height + ")").call(d3.axisBottom(x));
    
    const y = d3.scaleLinear().domain(d3.extent(data, (d) => {return +d.Item2;})).range([height, 0]);
    svg.append("g").call(d3.axisLeft(y));
    return {svg, x, y};
}