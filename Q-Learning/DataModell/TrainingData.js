const loadRewardGraph = () => {
    const {svg, x, y} = prepareSvg("#reward_chart", 1200, 450, rewards);
    svg.append('g')
       .selectAll("dot")
       .data(rewards)
       .enter()
       .append("circle")
            .attr("cx", (d) => {return x(d.Item1)})
            .attr("cy", (d) => {return y(d.Item2)})
            .attr("r", 1.5)
            .style("fill", "#d90b0b")
}

const loadFailureGraph = () => {
    const {svg, x, y} = prepareSvg("#failure_chart", 1000, 450, failures);
    svg.append("path")
       .datum(failures)
       .attr("fill", "none")
       .attr("stroke", "steelblue")
       .attr("stroke-width", 1.5)
       .attr("d", d3.line().x((d)=> { return x(d.Item1)})
                           .y((d)=> {return y(d.Item2)}))
    
}

const loadSuccessGraph = () => {
    const {svg, x, y} = prepareSvg("#succes_chart", 1000, 450, successes);
    svg.append("path")
       .datum(successes)
       .attr("fill", "none")
       .attr("stroke", "lawnGreen")
       .attr("stroke-width", 1.5)
       .attr("d", d3.line().x((d)=> { return x(d.Item1)})
                           .y((d)=> {return y(d.Item2)}))
    
}

loadRewardGraph();
loadFailureGraph();
loadSuccessGraph();