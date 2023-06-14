import React from "react";
import ReactDOM from "react-dom/client";
import { ChakraProvider } from "@chakra-ui/react";
import Navbar from "../components/Navbar";
import { Link, Heading, Text } from "@chakra-ui/react";

const Home = () => {
  return (
    <>
      <Navbar />
      <Heading as="b" size="lg">
        Select option{" "}
      </Heading>
      <br />
      <Text>
        <Link>Record sales</Link>
      </Text>
      <br />
      <Text>
        <Link>Record incoming orders</Link>
      </Text>
      <br />
      <Text>
        <Link>View inventory</Link>
      </Text>
      <br />
      <Text>
        <Link>View sales report</Link>
      </Text>
    </>
  );
};

export default Home;
