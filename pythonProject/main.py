#CALEB OSHUST
import socket
import json

def connect_to_server(host='localhost', port=5000):
    try:
        client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        client_socket.connect((host, port))
        print("Connected to the server.")
        return client_socket
    except Exception as e:
        print(f"Connection error: {e}")
        return None


def find_most_common_character(data):
    return max(data, key=data.count)


def count_uppercase(data):
    return sum(1 for char in data if char.isupper())


def start_client():
    client_socket = connect_to_server()
    if not client_socket:
        return

    try:
        # Receive data from the server
        data = client_socket.recv(1024)
        random_characters = json.loads(data.decode('utf-8'))
        print(f"Received characters: {random_characters}")

        # Find the most common character
        # Find the most common character
        most_common_char = find_most_common_character(random_characters)
        count = random_characters.count(most_common_char)
        print(f"Most common character: {most_common_char} (Count: {count})")

        # Count uppercase characters and check the condition
        uppercase_count = count_uppercase(random_characters)
        total_characters = len(random_characters)

        if uppercase_count >= total_characters / 2:
            print("Upper")
        else:
            print("Lower")
            # Send the name back to the server
        my_name = "Caleb"
        client_socket.sendall(my_name.encode('utf-8'))
        print(f"Sent {my_name}")
    except Exception as e:
        print(f"Error: {e}")
    finally:
        client_socket.close()


if __name__ == '__main__':
    start_client()
