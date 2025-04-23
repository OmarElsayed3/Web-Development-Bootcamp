import { useState } from 'react';
import './App.css';
import {Stack, Button, Checkbox, List, ListItem, ListItemText, TextField, Paper, IconButton, Typography, Box} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import CheckIcon from '@mui/icons-material/Check';

interface Task {
  text: string;
  completed: boolean;
}

function App() {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [newTask, setNewTask] = useState<string>('');

  const addTask = () => {
    if (newTask.trim() !== '') {
      setTasks([...tasks, { text: newTask, completed: false }]);
      setNewTask('');
    }
  };

  const toggleTaskCompletion = (index: number) => {
    const updatedTasks = tasks.map((task, i) =>
      i === index ? { ...task, completed: !task.completed } : task
    );
    setTasks(updatedTasks);
  };

  const deleteTask = (index: number) => {
    const updatedTasks = tasks.filter((_, i) => i !== index);
    setTasks(updatedTasks);
  };

  return (
    <Box sx={{ maxWidth: 600, margin: 'auto', p: 2 }}>
      <Typography variant="h4" sx={{ color: 'black', textAlign: 'center', mb: 2 }}>
        Todo App
      </Typography>
      <Stack direction="row" spacing={2} mb={2}>
        <TextField
          label="Add a new task"
          fullWidth
          size="small"
          value={newTask}
          onChange={(e) => setNewTask(e.target.value)}
          onKeyPress={(e) => e.key === 'Enter' && addTask()}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={addTask}
          disabled={!newTask.trim()}
          sx={{ textTransform: 'uppercase', fontWeight: 'bold' }}
        >
          Add
        </Button>
      </Stack>
      <Paper elevation={3} sx={{ p: 2 }}>
        {tasks.length === 0 ? (
          <Typography variant="body1" color="textSecondary" align="center">
            No tasks yet. Add a new task to get started!
          </Typography>
        ) : (
          <List>
            {tasks.map((task, index) => (
              <ListItem
                key={index}
                sx={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'space-between',
                  mb: 1,
                  backgroundColor: '#f9f9f9',
                  borderRadius: 1,
                  padding: 1,
                }}
              >
                <ListItemText
                  primary={task.text}
                  sx={{
                    textDecoration: task.completed ? 'line-through' : 'none',
                    color: task.completed ? 'gray' : 'black',
                    flexGrow: 1,
                  }}
                />
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                  <Checkbox
                    checked={task.completed}
                    onChange={() => toggleTaskCompletion(index)}
                    inputProps={{ 'aria-label': 'Mark task as completed' }}
                    icon={<CheckIcon sx={{ color: 'gray' }} />}
                    checkedIcon={<CheckIcon sx={{ color: 'green' }} />}
                  />
                  <IconButton
                    edge="end"
                    aria-label="delete"
                    onClick={() => deleteTask(index)}
                    sx={{ color: 'red' }}
                  >
                    <DeleteIcon />
                  </IconButton>
                </Box>
              </ListItem>
            ))}
          </List>
        )}
      </Paper>
    </Box>
  );
}

export default App;