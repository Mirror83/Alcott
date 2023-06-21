import React from "react";
import ReactDOM from "react-dom/client";
import { ChakraProvider } from "@chakra-ui/react";
import Navbar from "../components/Navbar";
import { Link, Heading, Text } from "@chakra-ui/react";

const Home = () => {
  return (
    <div>
      <Heading as="b" size="lg">
        Select option{" "}
      </Heading>
      <br />
      <Text>
        <Link href="/sales">Record sales</Link>
      </Text>
      <br />
      <Text>
        <Link href="/orders">Record incoming orders</Link>
      </Text>
      <br />
      <Text>
        <Link href="/inventory">View inventory</Link>
      </Text>
      <br />
      <Text>
        <Link href="/report">View sales report</Link>
      </Text>
    </div>
  );
};

export default Home;
